using LAB2.Logics;
using LAB2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormAction();
        }
        private void FormAction()
        {
            majorBox.SelectionChangeCommitted += (sender, e) =>
            {
                Major major = (Major)majorBox.SelectedItem;
                if (major.Code == "all")
                {
                    dataGridView1.DataSource = StudentManager.GetAllStudents();
                }
                else
                {
                    dataGridView1.DataSource = StudentManager.GetStudentByMajor(major.Code);
                }
            };
            // if dataGridView1 selected row changed, then show detail of selected student
            dataGridView1.SelectionChanged += (sender, e) =>
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Student student = (Student)dataGridView1.SelectedRows[0].DataBoundItem;
                    LoadDataToFields(student, false);
                }
            };
        }
        private void LoadDataToFields(Student student, bool isIdEnable)
        {
            idBox.Text = student.Id;
            idBox.Enabled = isIdEnable;
            nameBox.Text = student.Name;
            majorBox1.SelectedItem = student.Major;
            femaleRadio.Checked = true;
            if (!String.IsNullOrEmpty(student.Gender) && student.Gender.Equals("Male")) { maleRadio.Checked = true; }
            dateOfBirthBox.Value = student.Dob;
            scholarshipBox.Value = Convert.ToDecimal(student.Scholarship);
            isActiveBox.Checked = student.Active;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            // reset all fields
            LoadDataToFields(new Student(), true);

        }
        private Student? GetStudentFromFields()
        {
            Student student = new Student();
            // check if idBox not null and matches regex XX151359
            Regex regex = new Regex(@"^[A-Z]{2}[0-9]{6}$");
            if (String.IsNullOrEmpty(idBox.Text) || !regex.IsMatch(idBox.Text))
            {
                throw new Exception("Id của sinh viên không hợp lệ (XX151359)");
            }
            student.Id = idBox.Text;
            if (String.IsNullOrEmpty(nameBox.Text))
            {
                throw new Exception("Tên sinh viên không hợp lệ");
            }
            student.Name = nameBox.Text;
            student.Major = (Major)majorBox1.SelectedItem;
            student.Dob = dateOfBirthBox.Value;
            student.Scholarship = Convert.ToDouble(scholarshipBox.Value);
            student.Active = isActiveBox.Checked;
            student.Gender = maleRadio.Checked ? "Male" : "Female";
            return student;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = StudentManager.GetAllStudents();
            // find columns in dataGridView1 checked
            List<Major> majors = StudentManager.getAllMajors();
            majors.Insert(0, new Major("all", "All"));
            majorBox.DataSource = majors;
            majors.RemoveAt(0);
            List<Major> majors1 = new List<Major>();
            majors1.AddRange(majors);
            majorBox1.DataSource = majors1;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // check id box enabled or not
                if (idBox.Enabled)
                {
                    Student student = GetStudentFromFields();
                    if (StudentManager.InsertStudent(student) != 0)
                    {
                        MessageBox.Show("Thêm sinh viên thành công");
                        LoadDataToFields(new Student(), false);
                        dataGridView1.DataSource = StudentManager.GetAllStudents();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sinh viên thất bại");
                    }
                    //if (StudentManager.CheckStudentIsExit(student.Id) == 0)
                    //{

                    //}
                    //else
                    //{
                    //    MessageBox.Show("Mã sinh viên đã tồn tại");
                    //}
                }
                else
                {
                    MessageBox.Show($"Bạn đang sử dụng chức năng sửa thông tin sinh viên {Environment.NewLine}Vui lòng nhấn reset để thực hiện chức năng thêm mới");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete");
                return;
            }
            else
            {
                String id = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
                // show confirm dialog
                DialogResult result = MessageBox.Show("Are you sure to delete this student?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (StudentManager.DeleteStudent(id) > 0)
                    {
                        MessageBox.Show("Xóa sinh viên thành công");
                        dataGridView1.DataSource = StudentManager.GetAllStudents();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sinh viên thất bại");
                    }
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // check id box enabled or not
                Student student = GetStudentFromFields();
                if (StudentManager.UpdateStudent(student) != 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    dataGridView1.DataSource = StudentManager.GetAllStudents();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}

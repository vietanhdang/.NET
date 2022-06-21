using System;
using System.Collections.Generic;

#nullable disable

namespace FIrstWebApp.Models
{
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        public string Code { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

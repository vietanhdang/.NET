﻿using System;
using System.Collections.Generic;
using System.IO;

namespace LAB1
{

    internal class Program
    {

        static void Main(string[] args)
        {
            String filename = @"D:\Semester 5\PRN211\Day1-10-5-2022\LAB1\students.txt";
            StudentController studentController = new StudentController();
            Console.WriteLine("============================Read from file=================");
            studentController.ReadStudentFromFile(filename);
            Console.WriteLine("============================Read from file done=================");
            while (true)
            {
                int choice = studentController.Menu();
                switch (choice)
                {
                    case 1:
                        int id = InputReader.ReadInt("Enter id: ");
                        Console.WriteLine(studentController.FindStudentById(id));
                        break;
                    case 2:
                        String name = InputReader.ReadString("Enter name: ");
                        studentController.FindStudentsByName(name).Display();
                        break;
                    case 3:
                        String major = InputReader.ReadString("Enter major: ");
                        studentController.FindStudentsByMajor(major).Display();
                        break;
                    case 4:
                        float Schoolarship = InputReader.ReadFloat("Enter schoolarship: ");
                        String major1 = InputReader.ReadString("Enter major: ");
                        studentController.FindStudentsByMajorAndSchoolar(major1, Schoolarship).Display();
                        break;
                    case 5:
                        int year = InputReader.ReadInt("Enter year: ");
                        studentController.FindStudentsByYearOfBirth(year).Display();
                        break;
                    case 6:
                        DateTime date1 = InputReader.ReadDate("Enter date1: ");
                        DateTime date2 = InputReader.ReadDate("Enter date2: ");
                        studentController.FindStudentsByDateOfBirth(date1, date2).Display();
                        break;
                    case 7:
                        int yearAdmitted = InputReader.ReadInt("Enter yearAdmitted: ");
                        studentController.FindStudentsByYearAdmitted(yearAdmitted).ForEach(x => Console.WriteLine(x));
                        break;
                    case 8:
                        int min = InputReader.ReadInt("Enter min schollar ship: ");
                        int max = InputReader.ReadInt("Enter max schollar ship: ");
                        studentController.FindStudentsHasSchollarship(min, max).Display();
                        break;
                    case 9:
                        studentController.DisplayAllStudent();
                        break;
                    case 10:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}

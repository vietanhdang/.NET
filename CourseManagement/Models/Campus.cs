﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CourseManagement.Models
{
    public partial class Campus
    {
        public Campus()
        {
            Courses = new HashSet<Course>();
            Rooms = new HashSet<Room>();
        }

        public int CampusId { get; set; }
        public string CampusCode { get; set; }
        public string CampusName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}

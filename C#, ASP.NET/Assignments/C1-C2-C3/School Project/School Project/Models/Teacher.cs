using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Project.Models
{
    public class Teacher
    {
        //The following fields define a Teacher
        public int TeacherId;
        public string TeacherFName;
        public string TeacherLName;
        public string EmployeNumber;
        public DateTime HireDate;
        public decimal Salary;

        public Teacher() { }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace School_Project.Models
{
    public class Class
    {
        //The following fields define a Class
        public int ClassId;
        public string ClassCode;
        public int TeacherId;
        public DateTime StartDate;
        public DateTime FinishDate;
        public string ClassName;

        public Class() { }
    }
}
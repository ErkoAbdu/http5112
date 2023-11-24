using MySql.Data.MySqlClient;
using School_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace School_Project.Controllers
{
    public class TeacherDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Returns list of Teachers in the database
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers</example>
        /// <returns>List of Teachers (first and last names)</returns>

        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        public IEnumerable<Teacher> ListTeachers(string SearchKey=null)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers where lower(teacherfname) like lower (@key) or lower(teacherlname) like lower (@key) or lower(concat(teacherfname, ' ', teacherlname)) like lower (@key)";

            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teachers
            List<Teacher> Teachers = new List<Teacher> {};

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFName = (string)ResultSet["teacherfname"];
                string TeacherLName = (string)ResultSet["teacherlname"];
                string EmployeeNumber = (string)ResultSet["employeenumber"];
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal Salary = (decimal)ResultSet["salary"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFName = TeacherFName;
                NewTeacher.TeacherLName = TeacherLName;
                NewTeacher.EmployeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
                //Add the Teacher Name to the List
                Teachers.Add(NewTeacher);
            }
            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of Teacher names
            return Teachers;
        }
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers where teacherid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFName = (string)ResultSet["teacherfname"];
                string TeacherLName = (string)ResultSet["teacherlname"];
                string EmployeeNumber = (string)ResultSet["employeenumber"];
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal Salary = (decimal)ResultSet["salary"];

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFName = TeacherFName;
                NewTeacher.TeacherLName = TeacherLName;
                NewTeacher.EmployeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
            }

            return NewTeacher;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <example>POST: /api/TeacherData/DeleteTeacher/3</example>
        [HttpPost]
        public void DeleteTeacher(int id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Delete from teachers where teacherid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }
    }
}

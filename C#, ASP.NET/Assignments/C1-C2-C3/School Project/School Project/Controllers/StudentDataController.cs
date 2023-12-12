using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using School_Project.Models;

namespace School_Project.Controllers
{
    public class StudentDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Gets a list of students 
        /// </summary>
        /// <param name="SearchKey"> used to search for specific students</param>
        /// <returns>displays list of all students within the database</returns>

        [HttpGet]
        [Route("api/StudentData/ListStudents/{SearchKey?}")]
        public IEnumerable<Student> ListStudents(string SearchKey=null)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from students where lower(studentfname) like lower(@key) or lower(studentlname) like lower(@key) or lower(concat(studentfname, ' ', studentlname)) like lower(@key)";

            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Students
            List<Student> Students = new List<Student> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFName = (string)ResultSet["studentfname"];
                string StudentLName = (string)ResultSet["studentlname"];
                string StudentNumber = (string)ResultSet["studentnumber"];
                DateTime EnrolDate = (DateTime)ResultSet["enroldate"];

                Student NewStudent = new Student();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFName = StudentFName;
                NewStudent.StudentLName = StudentLName;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;
                //Add the Student Name to the List
                Students.Add(NewStudent);
            }
            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();
            //Return the final list of Student names
            return Students;
        }
        /// <summary>
        /// gets a specific student by their id
        /// </summary>
        /// <param name="id">this is the id to find the student</param>
        /// <example>/Student/Show/34</example>
        /// <returns>Erko Abdurahman</returns>
        [HttpGet]
        public Student FindStudent(int id)
        {
            Student NewStudent = new Student();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from students where studentid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFName = (string)ResultSet["studentfname"];
                string StudentLName = (string)ResultSet["studentlname"];
                string StudentNumber = (string)ResultSet["studentnumber"];
                DateTime EnrolDate = (DateTime)ResultSet["enroldate"];

                NewStudent.StudentId = StudentId;
                NewStudent.StudentFName = StudentFName;
                NewStudent.StudentLName = StudentLName;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;
            }
            return NewStudent;
        }
        /// <summary>
        /// deletes specified student by their id
        /// </summary>
        /// <param name="id"> identifies the student that is going to be deleted</param>
        /// <example>/Student/Show/34</example>
        /// <returns>id 34 student is deleted</returns>
        [HttpPost]
        public void DeleteStudent(int id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Delete from students where studentid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }
        /// <summary>
        /// adds a student to the database
        /// </summary>
        /// <param name="NewStudent">object to hold new student data</param>
        /// <example>Student/New/</example>
        /// <returns>newly created student with respective information tied to it</returns>
        [HttpPost]
        public void AddStudent([FromBody]Student NewStudent)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "insert into students(studentfname, studentlname, studentnumber, enroldate) values(@StudentFName, @StudentLName, @StudentNumber, @EnrolDate)";
            cmd.Parameters.AddWithValue("@StudentFName", NewStudent.StudentFName);
            cmd.Parameters.AddWithValue("@StudentLName", NewStudent.StudentLName);
            cmd.Parameters.AddWithValue("@StudentNumber", NewStudent.StudentNumber);
            cmd.Parameters.AddWithValue("@EnrolDate", NewStudent.EnrolDate);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        public void UpdateStudent(int id, [FromBody] Student StudentInfo)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "update students set studentfname = @StudentFName, studentlname = @StudentLName, studentnumber = @StudentNumber, enroldate = @EnrolDate where studentid = @StudentId";
            cmd.Parameters.AddWithValue("@StudentFName", StudentInfo.StudentFName);
            cmd.Parameters.AddWithValue("@StudentLName", StudentInfo.StudentLName);
            cmd.Parameters.AddWithValue("@StudentNumber", StudentInfo.StudentNumber);
            cmd.Parameters.AddWithValue("@EnrolDate", StudentInfo.EnrolDate);
            cmd.Parameters.AddWithValue("@StudentId", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();

        }
    }
}
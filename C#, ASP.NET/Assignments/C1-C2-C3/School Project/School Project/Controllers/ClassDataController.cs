using MySql.Data.MySqlClient;
using School_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace School_Project.Controllers
{
    public class ClassDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Gets a list of classes 
        /// </summary>
        /// <param name="SearchKey"> used to search for specific classes</param>
        /// <returns>displays list of all classes within the database</returns>

        [HttpGet]
        [Route("api/ClassesData/ListClasses/{SearchKey?}")]
        public IEnumerable<Class> ListClasses(string SearchKey=null)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes where lower(classcode) like lower(@key) or lower(classname) like lower(@key) or lower(concat(classcode, ' ', classname)) like lower(@key)";

            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Classes
            List<Class> Classes = new List<Class> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = (int)ResultSet["classid"];
                string ClassCode = (string)ResultSet["classcode"];
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = (string)ResultSet["classname"];

                Class NewClass = new Class();
                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;
                //Add the Class Name to the List
                Classes.Add(NewClass);
            }
            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();
            //Return the final list of Class names
            return Classes;
        }
        /// <summary>
        /// gets a specific class by its id
        /// </summary>
        /// <param name="id">this is the id to find the class</param>
        /// <example>/Class/Show/14</example>
        /// <returns>EA24 - Erkos Test</returns>
        [HttpGet]
        public Class FindClass(int id)
        {
            Class NewClass = new Class();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes where classid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();


            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = (int)ResultSet["classid"];
                string ClassCode = (string)ResultSet["classcode"];
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = (string)ResultSet["classname"];

                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;
            }

            return NewClass;

        }

        /// <summary>
        /// deletes specified class by its id
        /// </summary>
        /// <param name="id"> identifies the class that is going to be deleted</param>
        /// <example>/Class/Show/14</example>
        /// <returns>id 14 class is deleted</returns>
        [HttpPost]
        public void DeleteClass(int id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Delete from classes where classid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }
        /// <summary>
        /// adds a class to the database
        /// </summary>
        /// <param name="NewClass">object to hold new class data</param>
        /// <example>Teacher/New/</example>
        /// <returns>newly created teacher with respective information tied to it</returns>
        [HttpPost]
        public void AddClass([FromBody] Class NewClass)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "insert into classes(classcode, teacherid, startdate, finishdate, classname) values(@ClassCode, @TeacherId, @StartDate, @FinishDate, @ClassName)";
            cmd.Parameters.AddWithValue("@ClassCode", NewClass.ClassCode);
            cmd.Parameters.AddWithValue("@TeacherId", NewClass.TeacherId);
            cmd.Parameters.AddWithValue("@StartDate", NewClass.StartDate);
            cmd.Parameters.AddWithValue("@FinishDate", NewClass.FinishDate);
            cmd.Parameters.AddWithValue("@ClassName", NewClass.ClassName);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        public void UpdateClass(int id, [FromBody] Class ClassInfo)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "update classes set classcode = @ClassCode, teacherid = @TeacherId, startdate = @StartDate, finishdate = @FinishDate, classname = @ClassName where teacherid = @TeacherId";
            cmd.Parameters.AddWithValue("@ClassCode", ClassInfo.ClassCode);
            cmd.Parameters.AddWithValue("@TeacherId", ClassInfo.TeacherId);
            cmd.Parameters.AddWithValue("@StartDate", ClassInfo.StartDate);
            cmd.Parameters.AddWithValue("@FinishDate", ClassInfo.FinishDate);
            cmd.Parameters.AddWithValue("@ClassName", ClassInfo.ClassName);
            cmd.Parameters.AddWithValue("@ClassId", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();

        }
    }
}

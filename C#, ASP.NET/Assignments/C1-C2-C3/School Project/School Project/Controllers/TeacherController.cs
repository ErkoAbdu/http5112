using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_Project;
using School_Project.Models;

namespace School_Project.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET: /Teacher/List
        public ActionResult List(string SearchKey=null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        //GET: /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);
            

            return View(SelectedTeacher);
        }
        //GET:/Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }

        //POST: /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET: /Teacher/New
        public ActionResult New()
        {

            return View();
        }

        //POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFName, string TeacherLName, string EmployeeNumber, DateTime HireDate, decimal Salary)
        {
            Debug.WriteLine("IT WORKS");
            Debug.WriteLine(TeacherFName);
            Debug.WriteLine(TeacherLName);
            Debug.WriteLine(EmployeeNumber);

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFName = TeacherFName;
            NewTeacher.TeacherLName = TeacherLName;
            NewTeacher.EmployeNumber = EmployeeNumber;
            NewTeacher.HireDate = HireDate;
            NewTeacher.Salary = Salary;


            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }

        //GET : /Teacher/Update
        /// <summary>
        /// Takes you to Teacher update page and takes information from database
        /// </summary>
        /// <param name="id">Id of the Teacher</param>
        /// <returns>Provides the current info of Teacher and asks user for new info from the form</returns>
        /// <example>GET : /Teacher/Update/{id}</example>
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }

        //POST : /Teacher/Update/[id]
        /// <summary>
        /// Recieves POST request with info about existing teacher in system with new values. Tells the API about the info and redirects to the Teacher Show page of updated Teacher
        /// </summary>
        /// <param name="id">Id of Teacher being updated</param>
        /// <param name="TeacherFName">Updated first name of Teacher</param>
        /// <param name="TeacherLName">Updated last name of Teacher</param>
        /// <param name="EmployeeNumber">Updated Employeenumber of Teacher</param>
        /// <param name="HireDate">Updated HireDate of Teacher</param>
        /// <param name="Salary">Updated Salary of Teacher</param>
        /// <returns>New information of selected Teacher</returns>
        /// <example>
        /// POST : /Teacher/Update/2
        /// FORM Data / POST Data / Request Body
        /// {
        /// "TeacherFName":"Jefe",
        /// "TeacherLName":"TheCat",
        /// "EmployeeNumber":"M123",
        /// "HireDate":"2023-12-11",
        /// "Salary":"123"
        /// }
        /// </example>

        [HttpPost]
        public ActionResult Update(int id, string TeacherFName, string TeacherLName, string EmployeeNumber, DateTime HireDate, decimal Salary)
        {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFName = TeacherFName;
            TeacherInfo.TeacherLName = TeacherLName;
            TeacherInfo.EmployeNumber = EmployeeNumber;
            TeacherInfo.HireDate = HireDate;
            TeacherInfo.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);

            return RedirectToAction("Show/" + id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using School_Project;
using School_Project.Models;

namespace School_Project.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }
        //GET: /Class/List
        public ActionResult List(string SearchKey=null)
        {
            ClassDataController controller = new ClassDataController();
            IEnumerable<Class> Classes = controller.ListClasses(SearchKey);
            return View(Classes);
        }

        //GET: /Class/Show/{id}
        public ActionResult Show(int id)
        {
            ClassDataController controller = new ClassDataController();
            Class NewClass = controller.FindClass(id);

            return View(NewClass);
        }

        //GET: /Class/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            ClassDataController controller = new ClassDataController();
            Class NewClass = controller.FindClass(id);

            return View(NewClass);
        }

        //POST: /Class/Delete/{id}
        public ActionResult Delete(int id)
        {
            ClassDataController controller = new ClassDataController();
            controller.DeleteClass(id);
            return RedirectToAction("List");
        }

        //GET: /Class/New
        public ActionResult New()
        {

            return View();
        }

        //POST: /Class/Create
        [HttpPost]
        public ActionResult Create(string ClassCode, int TeacherId, DateTime StartDate, DateTime FinishDate, string ClassName)
        {
            Debug.Write("IT WORKS");

            Class NewClass = new Class();
            NewClass.ClassCode = ClassCode;
            NewClass.TeacherId = TeacherId;
            NewClass.StartDate = StartDate;
            NewClass.FinishDate = FinishDate;
            NewClass.ClassName = ClassName;


            ClassDataController controller = new ClassDataController();
            controller.AddClass(NewClass);

            return RedirectToAction("List");
        }

        public ActionResult Update(int id)
        {
            ClassDataController controller = new ClassDataController();
            Class SelectedClass = controller.FindClass(id);

            return View(SelectedClass);
        }

        //POST : /Class/Update/[id]
        /// <summary>
        /// Recieves POST request with info about existing Class in system with new values. Tells the API about the info and redirects to the Class Show page of updated Class
        /// </summary>
        /// <param name="id">Id of CLass being updated</param>
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
        public ActionResult Update(int id, string ClassCode, int TeacherId, DateTime StartDate, DateTime FinishDate, string ClassName)
        {
            Class ClassInfo = new Class();
            ClassInfo.ClassCode = ClassCode;
            ClassInfo.TeacherId = TeacherId;
            ClassInfo.StartDate = StartDate;
            ClassInfo.FinishDate = FinishDate;
            ClassInfo.ClassName = ClassName;

            ClassDataController controller = new ClassDataController();
            controller.UpdateClass(id, ClassInfo);

            return RedirectToAction("Show/" + id);
        }
    }
}
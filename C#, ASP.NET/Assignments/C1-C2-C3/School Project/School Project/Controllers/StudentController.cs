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
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        //GET: /Student/List
        public ActionResult List(string SearchKey=null)
        {
            StudentDataController controller = new StudentDataController();
            IEnumerable<Student> Students = controller.ListStudents(SearchKey);
            return View(Students);
        }

        //GET: /Student/Show/{id}
        public ActionResult Show(int id)
        {
            StudentDataController controller = new StudentDataController();
            Student NewStudent = controller.FindStudent(id);

            return View(NewStudent);
        }

        //GET: /Student/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            StudentDataController controller = new StudentDataController();
            Student NewStudent = controller.FindStudent(id);

            return View(NewStudent);
        }

        //POST: /Student/Delete/{id}
        public ActionResult Delete(int id)
        {
            StudentDataController controller = new StudentDataController();
            controller.DeleteStudent(id);
            return RedirectToAction("List");
        }

        //GET: /Student/New
        public ActionResult New()
        {

            return View();
        }

        //POST: /Student/Create
        [HttpPost]
        public ActionResult Create(string StudentFName, string StudentLName, string StudentNumber, DateTime EnrolDate)
        {
            Debug.Write("IT WORKS");

            Student NewStudent = new Student();
            NewStudent.StudentFName = StudentFName;
            NewStudent.StudentLName = StudentLName;
            NewStudent.StudentNumber = StudentNumber;
            NewStudent.EnrolDate = EnrolDate;

            StudentDataController controller = new StudentDataController();
            controller.AddStudent(NewStudent);

            return RedirectToAction("List");
        }

        public ActionResult Update(int id)
        {
            StudentDataController controller = new StudentDataController();
            Student SelectedStudent = controller.FindStudent(id);

            return View(SelectedStudent);
        }

        //POST : /Student/Update/[id]
        /// <summary>
        /// Recieves POST request with info about existing Student in system with new values. Tells the API about the info and redirects to the Student Show page of updated Student
        /// </summary>
        /// <param name="id">Id of Student being updated</param>
        /// <param name="StudentFName">Updated first name of Student</param>
        /// <param name="StudentLName">Updated last name of Student</param>
        /// <param name="StudentNumber">Updated Studentnumber of Student</param>
        /// <param name="EnrolDate">Updated EnrolDate of Student</param>
        /// <returns>New information of selected Student</returns>
        /// <example>
        /// POST : /Student/Update/2
        /// FORM Data / POST Data / Request Body
        /// {
        /// "StudentFName":"Jefe",
        /// "StudentLName":"TheCat",
        /// "StudentNumber":"M123",
        /// "EnrolDate":"2023-12-11",
        /// }
        /// </example>

        [HttpPost]
        public ActionResult Update(int id, string StudentFName, string StudentLName, string StudentNumber, DateTime EnrolDate)
        {
            Student StudentInfo = new Student();
            StudentInfo.StudentFName = StudentFName;
            StudentInfo.StudentLName = StudentLName;
            StudentInfo.StudentNumber = StudentNumber;
            StudentInfo.EnrolDate = EnrolDate;

            StudentDataController controller = new StudentDataController();
            controller.UpdateStudent(id, StudentInfo);

            return RedirectToAction("Show/" + id);
        }
    }
}
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
    }
}
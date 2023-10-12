using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CostumeStore.Controllers
{
    public class CostumeController : Controller
    {
        // GET: Costume
        public ActionResult Index()
        {
            return View();
        }
        //GET: localhost:xx/Costume/Order
        //Route to/ Views/Costume/Order.cshtml
        
        public ActionResult Order() 
        {
            return View();
        }

        //GET: Local:xx/Costume/Checkout
        //Route to/Views/Costume/Checkout.cshtml

        public ActionResult 
    }
}
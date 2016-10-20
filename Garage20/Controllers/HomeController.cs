using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage20.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to Garage 2.0 in Stockholm";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact info below:";

            return View();
        }
    }
}
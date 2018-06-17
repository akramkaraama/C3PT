using BOL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WPG_ICSC_PT.Controllers
{
    public class HomeController : Controller
    {
        WPG_ConferenceEntities wpgDb = null;
        EmployeeBL empBL = null;

        public HomeController()
        {
            wpgDb = new WPG_ConferenceEntities();
            empBL = new EmployeeBL();
        }

        public ActionResult Index()
        {             
            //List<Employee> employees = empBL.GetALL().ToList();

            return View(empBL.GetALL().ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

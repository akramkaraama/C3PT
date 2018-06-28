using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPG_ICSC_PT.Models;

namespace WPG_ICSC_PT.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult TestCreate()
        {
            var testModel = new TestModel()
            {
                Employee = new Employee(),
                Note = new Note(),
                Guest = new Guest(),
                Meeting = new Meeting()
            };
            return View(testModel);
        }

        [HttpPost]
        public ActionResult Create(TestModel test)
        {
            return View();
        }
    }
}
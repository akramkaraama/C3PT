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
        WPG_ConferenceEntities wpgDb;
        HomeViewModel homeVM;
        EmployeeBL empBL;
        

        public HomeController()
        {
            wpgDb = new WPG_ConferenceEntities();
            homeVM = new HomeViewModel();
            //empBL = new EmployeeBL();
        }

        public ActionResult Index(int Id)
        {
            var employees = wpgDb.Employees.ToList();
            var meetings = wpgDb.Meetings.ToList();

            var employeeMeetings = wpgDb.Meetings.Where(x => x.Id == Id).ToList();

            var viewModel = new HomeViewModel();
            viewModel.employees = employees;
            viewModel.meetings = meetings;
            viewModel.empMeetings = wpgDb.Meeting_Employee.Where(x => x.Employee_Id == Id).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ListEmployeeMeeting(Employee Id)
        {
            var employees = wpgDb.Employees.ToList();
            var meetings = wpgDb.Meetings.ToList();
            
            var employeeMeetings = new List<Meeting>();
            foreach (var id in meetings)
            {
                var mtng = wpgDb.Meetings.Find(Id);
                employeeMeetings.Add(mtng);
            }

            var viewModel = new HomeViewModel();
            viewModel.employees = employees;
            viewModel.meetings = employeeMeetings;
            //viewModel.empMeetings = employeeMeetings;

            //List<Meeting> empMeetings = homeVM.meetings.Where(x => x.Meeting_Employee == Id);
            return View("Index", viewModel);
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

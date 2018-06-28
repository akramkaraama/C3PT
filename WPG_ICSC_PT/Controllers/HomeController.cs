using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using BOL;

namespace WPG_ICSC_PT.Controllers
{
    public class HomeController : Controller
    {
        private WPG_ConferenceEntities wpgDb;
        private List<Employee> emp;

        public HomeController()
        {
            wpgDb = new WPG_ConferenceEntities();
            //List<WPG_ConferenceEntities> emp = null;
        }

        public ActionResult Index(int? page)
        {
            if (User.IsInRole("A"))
            {
                emp = wpgDb.Employees.Include(x => x.Employee_Guest).Include(x => x.Meeting_Employee).Include(x => x.Role).Where(x => x.Role.Role1 == "LA" || x.Role.Role1 == "A").ToList();
            }
            else if (User.IsInRole("LA"))
            {
                emp = wpgDb.Employees.Include(x => x.Employee_Guest).Include(x => x.Meeting_Employee).Include(x => x.Role).Where(x => x.Role.Role1 == "LA").ToList();
            }
            else if (User.IsInRole("BE"))
            {
                emp = wpgDb.Employees.Include(x => x.Employee_Guest).Include(x => x.Meeting_Employee).Include(x => x.Role).ToList();               
            }
            else if (User.IsInRole("E"))
            {
                emp = wpgDb.Employees.Include(x => x.Employee_Guest).Include(x => x.Meeting_Employee).Include(x => x.Role).ToList();
            }
            //emp = wpgDb.Employees.Include(x => x.Employee_Guest).Include(x => x.Meeting_Employee).Include(x => x.Role).ToList();
            return View(emp.OrderByDescending(x => x.Meeting_Employee.Count > 0).ToPagedList(page ?? 1, 20));
        }
    }
}



//WPG_ConferenceEntities wpgDb;
//HomeViewModel homeVM;
//EmployeeBL empBL;

//public HomeController()
//{
//    wpgDb = new WPG_ConferenceEntities();
//    homeVM = new HomeViewModel();
//    empBL = new EmployeeBL();
//}

//public ActionResult Index(int Id)
//{
//    var employees = wpgDb.Employees.ToList();
//    var meetings = wpgDb.Meetings.ToList();

//    var employeeMeetings = wpgDb.Meetings.Where(x => x.Id == Id).ToList();

//    var viewModel = new HomeViewModel();
//    viewModel.employees = employees;
//    viewModel.meetings = meetings;
//    viewModel.employee_Meetings = wpgDb.Meeting_Employee.Where(x => x.Employee_Id == Id).ToList();

//    return View(viewModel);
//}

//[HttpPost]
//public ActionResult ListEmployeeMeeting(Employee Id)
//{
//    var employees = wpgDb.Employees.ToList();
//    var meetings = wpgDb.Meetings.ToList();

//    var employeeMeetings = new List<Meeting>();
//    foreach (var id in meetings)
//    {
//        var mtng = wpgDb.Meetings.Find(Id);
//        employeeMeetings.Add(mtng);
//    }

//    var viewModel = new HomeViewModel();
//    viewModel.employees = employees;
//    viewModel.meetings = employeeMeetings;
//    //viewModel.empMeetings = employeeMeetings;

//    //List<Meeting> empMeetings = homeVM.meetings.Where(x => x.Meeting_Employee == Id);
//    return View("Index", viewModel);
//}
//    }
//}

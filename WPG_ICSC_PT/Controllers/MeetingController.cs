using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WPG_ICSC_PT.Controllers
{
    public class MeetingController : Controller
    {
        private WPG_ConferenceEntities wpgDb;
        public MeetingController()
        {
            wpgDb = new WPG_ConferenceEntities();
        }
        // GET: Meeting
        public PartialViewResult EmployeeMeetings(int? empId)
        {
            var empMeeting = wpgDb.MeetingEmployees.Include(x => x.Employee).Include(x => x.Meeting).
                Where(x => x.Employee_Id == empId).Select(x => x.Meeting).ToList();

            var firstName = (from emp in wpgDb.Employees where emp.Id == empId select emp.F_Name).FirstOrDefault();
            var lastName = (from emp in wpgDb.Employees where emp.Id == empId select emp.L_Name).FirstOrDefault();
            ViewBag.EmployeeName = firstName + " " + lastName + "\'s";

            var emplId = (from emp in wpgDb.Employees where emp.Id == empId select emp.Id).FirstOrDefault();
            ViewBag.EmpId = empId;

            return PartialView(empMeeting);
        }

        public PartialViewResult MeetingDetails(int? meetingId)
        {
            var meetingInfo = wpgDb.Meetings.Include(x => x.Notes).FirstOrDefault(x => x.Id == meetingId);
            return PartialView(meetingInfo);
        }

        public ActionResult Create()
        {
            ViewBag.MeetingStatus_id = new SelectList(wpgDb.MeetingStatus, "id", "status");
            ViewBag.MeetingType_id = new SelectList(wpgDb.MeetingTypes, "id", "meeting_type");

            ViewBag.Employee_Id = new SelectList(wpgDb.Employees.Select(e => e.F_Name + " " + e.L_Name), wpgDb.Employees, "Id");
            ViewBag.Guest_Id = new SelectList(wpgDb.Guests.Select(g => g.F_Name + " " + g.L_Name), wpgDb.Guests, "Id");
            ViewBag.RequirementOption_Id = new SelectList(wpgDb.RequirementOptions, "Id", "IsRequired");

            var scheduleMeetingVM = new ScheduleMeetingVewModel()
            {
                Employee = new Employee(),
                Note = new Note(),
                Meeting = new Meeting(),
                Guest = new Guest(),
                Company = new List<Company>(),
                MeetingEmployee = new MeetingEmployee()
            };

            return View(scheduleMeetingVM);
        }

        [HttpPost]
        public ActionResult Create(ScheduleMeetingVewModel viewModel, FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                var meeting = new Meeting()
                {
                    MeetingType_id = viewModel.Meeting.MeetingType_id,
                    Meeting_Date = viewModel.Meeting.Meeting_Date,
                    Date_Scheduled = System.DateTime.Today.ToLocalTime(),
                    Topic = viewModel.Meeting.Topic,
                    MeetingStatus_id = viewModel.Meeting.MeetingStatus_id,
                };

                string employee_Id = formCollection["Employee_Id"];
                //string isRequired = formCollection["RequirementOption_Id"];

                MeetingEmployee meetingEmployee = new MeetingEmployee
                {
                    Meeting_Id = (from mtng in wpgDb.Meetings where mtng.Topic == viewModel.Meeting.Topic select mtng.Id).FirstOrDefault(),
                    //Meeting_Id = wpgDb.Meetings.Where(x => x.Topic == viewModel.Meeting.Topic).Select(x => x.Id).FirstOrDefault(),
                    Employee_Id = wpgDb.Employees.Where(x => (x.F_Name + " " + x.L_Name).ToString() == employee_Id).Select(x => x.Id).FirstOrDefault()
                };

                //meetingEmployee.RequirementOption_Id = wpgDb.RequirementOptions.Where(x => x.IsRequired == isRequired).Select(x => x.Id).FirstOrDefault();
                //meetingEmployee.RequirementOption_Id = wpgDb.RequirementOptions.Where(x => x.IsRequired == isRequired).Select(x => x.Id).FirstOrDefault();
                //meetingEmployee.RequirementOption_Id = (from reqOption in wpgDb.RequirementOptions where reqOption.IsRequired == isRequired select reqOption.Id).FirstOrDefault();

                string guest_Id = formCollection["Guest_Id"];
                var employeeGuest = new EmployeeGuest()
                {
                    Guest_Id = wpgDb.Guests.Where(x => (x.F_Name + " " + x.L_Name).ToString() == guest_Id).Select(x => x.Id).FirstOrDefault()
                };
                
                wpgDb.Meetings.Add(meeting);
                wpgDb.MeetingEmployees.Add(meetingEmployee);
                wpgDb.EmployeeGuests.Add(employeeGuest);
                wpgDb.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(viewModel);
            }
        }
    }
}
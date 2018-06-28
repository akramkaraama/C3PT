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
            var empMeeting = wpgDb.Meeting_Employee.Where(x => x.Employee_Id == empId).Select(x => x.Meeting).ToList();
            return PartialView(empMeeting);
        }

        public PartialViewResult MeetingDetails(int? meetingId)
        {
            var meetingInfo = wpgDb.Meetings.Find(meetingId);
            return PartialView(meetingInfo);
        }
    }
}
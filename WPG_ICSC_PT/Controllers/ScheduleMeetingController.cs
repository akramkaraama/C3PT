using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace WPG_ICSC_PT.Controllers
{
    public class ScheduleMeetingController : Controller
    {
        private WPG_ConferenceEntities db = new WPG_ConferenceEntities();

        //Get
        public ActionResult Create()
        {
            ViewBag.MeetingStatus_id = new SelectList(db.MeetingStatus, "id", "status");
            ViewBag.MeetingType_id = new SelectList(db.MeetingTypes, "id", "meeting_type");
            ViewBag.Company_id = new SelectList(db.Companies, "id", "company");

            var scheduleMeetingVM = new ScheduleMeetingVewModel()
            {
                Employee = new Employee(),
                Note = new Note(),
                Meeting = new Meeting(),
                Guest = new Guest(),
                Company = new List<Company>()
            };

            return View(scheduleMeetingVM);
        }

        // POST: ScheduleMeeting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Start_Time,End_Time,Meeting_Date,Date_Scheduled,Topic,MeetingStatus_id,MeetingType_id,Pause_Start_Time,Pause_End_Time")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                db.Meetings.Add(meeting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetingStatus_id = new SelectList(db.MeetingStatus, "id", "status", meeting.MeetingStatus_id);
            ViewBag.MeetingType_id = new SelectList(db.MeetingTypes, "id", "meeting_type", meeting.MeetingType_id);
            return View(meeting);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}



//// GET: ScheduleMeeting/Edit/5
//public ActionResult Edit(int? id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    Meeting meeting = db.Meetings.Find(id);
//    if (meeting == null)
//    {
//        return HttpNotFound();
//    }
//    ViewBag.MeetingStatus_id = new SelectList(db.MeetingStatus, "id", "status", meeting.MeetingStatus_id);
//    ViewBag.MeetingType_id = new SelectList(db.MeetingTypes, "id", "meeting_type", meeting.MeetingType_id);
//    return View(meeting);
//}

//// POST: ScheduleMeeting/Edit/5
//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Edit([Bind(Include = "Id,Start_Time,End_Time,Meeting_Date,Date_Scheduled,Topic,MeetingStatus_id,MeetingType_id,Pause_Start_Time,Pause_End_Time")] Meeting meeting)
//{
//    if (ModelState.IsValid)
//    {
//        db.Entry(meeting).State = EntityState.Modified;
//        db.SaveChanges();
//        return RedirectToAction("Index");
//    }
//    ViewBag.MeetingStatus_id = new SelectList(db.MeetingStatus, "id", "status", meeting.MeetingStatus_id);
//    ViewBag.MeetingType_id = new SelectList(db.MeetingTypes, "id", "meeting_type", meeting.MeetingType_id);
//    return View(meeting);
//}


// GET: ScheduleMeeting
//public ActionResult Index()
//{
//    var meetings = db.Meetings.Include(m => m.MeetingStatu).Include(m => m.MeetingType);
//    return View(meetings.ToList());
//}

// GET: ScheduleMeeting/Details/5
//public ActionResult Details(int? id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    Meeting meeting = db.Meetings.Find(id);
//    if (meeting == null)
//    {
//        return HttpNotFound();
//    }
//    return View(meeting);
//}

// GET: ScheduleMeeting/Create


// GET: ScheduleMeeting/Delete/5
//public ActionResult Delete(int? id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    Meeting meeting = db.Meetings.Find(id);
//    if (meeting == null)
//    {
//        return HttpNotFound();
//    }
//    return View(meeting);
//}

// POST: ScheduleMeeting/Delete/5
//[HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public ActionResult DeleteConfirmed(int id)
//{
//    Meeting meeting = db.Meetings.Find(id);
//    db.Meetings.Remove(meeting);
//    db.SaveChanges();
//    return RedirectToAction("Index");
//}



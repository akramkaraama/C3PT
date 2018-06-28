using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace WPG_ICSC_PT.Controllers
{
    public class MeetingEmployeeController : Controller
    {
        private WPG_ConferenceEntities db = new WPG_ConferenceEntities();

        // GET: MeetingEmployee
        public ActionResult Index()
        {
            var meeting_Employee = db.Meeting_Employee.Include(m => m.Employee).Include(m => m.Meeting);
            return View(meeting_Employee.ToList());
        }

        // GET: MeetingEmployee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting_Employee meeting_Employee = db.Meeting_Employee.Find(id);
            if (meeting_Employee == null)
            {
                return HttpNotFound();
            }
            return View(meeting_Employee);
        }

        // GET: MeetingEmployee/Create
        public ActionResult Create()
        {
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name");
            ViewBag.Meeting_Id = new SelectList(db.Meetings, "Id", "Topic");
            return View();
        }

        // POST: MeetingEmployee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Employee_Id,Meeting_Id,IsRequired")] Meeting_Employee meeting_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Meeting_Employee.Add(meeting_Employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", meeting_Employee.Employee_Id);
            ViewBag.Meeting_Id = new SelectList(db.Meetings, "Id", "Topic", meeting_Employee.Meeting_Id);
            return View(meeting_Employee);
        }

        // GET: MeetingEmployee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting_Employee meeting_Employee = db.Meeting_Employee.Find(id);
            if (meeting_Employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", meeting_Employee.Employee_Id);
            ViewBag.Meeting_Id = new SelectList(db.Meetings, "Id", "Topic", meeting_Employee.Meeting_Id);
            return View(meeting_Employee);
        }

        // POST: MeetingEmployee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Employee_Id,Meeting_Id,IsRequired")] Meeting_Employee meeting_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meeting_Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", meeting_Employee.Employee_Id);
            ViewBag.Meeting_Id = new SelectList(db.Meetings, "Id", "Topic", meeting_Employee.Meeting_Id);
            return View(meeting_Employee);
        }

        // GET: MeetingEmployee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting_Employee meeting_Employee = db.Meeting_Employee.Find(id);
            if (meeting_Employee == null)
            {
                return HttpNotFound();
            }
            return View(meeting_Employee);
        }

        // POST: MeetingEmployee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meeting_Employee meeting_Employee = db.Meeting_Employee.Find(id);
            db.Meeting_Employee.Remove(meeting_Employee);
            db.SaveChanges();
            return RedirectToAction("Index");
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

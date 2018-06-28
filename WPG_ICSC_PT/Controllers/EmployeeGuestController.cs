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
    public class EmployeeGuestController : Controller
    {
        private WPG_ConferenceEntities db = new WPG_ConferenceEntities();

        // GET: EmployeeGuest
        public ActionResult Index()
        {
            var employee_Guest = db.Employee_Guest.Include(e => e.Employee).Include(e => e.Guest);
            return View(employee_Guest.ToList());
        }

        // GET: EmployeeGuest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Guest employee_Guest = db.Employee_Guest.Find(id);
            if (employee_Guest == null)
            {
                return HttpNotFound();
            }
            return View(employee_Guest);
        }

        // GET: EmployeeGuest/Create
        public ActionResult Create()
        {
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name");
            ViewBag.Guest_Id = new SelectList(db.Guests, "Id", "F_Name");
            return View();
        }

        // POST: EmployeeGuest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Employee_Id,Guest_Id")] Employee_Guest employee_Guest)
        {
            if (ModelState.IsValid)
            {
                db.Employee_Guest.Add(employee_Guest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", employee_Guest.Employee_Id);
            ViewBag.Guest_Id = new SelectList(db.Guests, "Id", "F_Name", employee_Guest.Guest_Id);
            return View(employee_Guest);
        }

        // GET: EmployeeGuest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Guest employee_Guest = db.Employee_Guest.Find(id);
            if (employee_Guest == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", employee_Guest.Employee_Id);
            ViewBag.Guest_Id = new SelectList(db.Guests, "Id", "F_Name", employee_Guest.Guest_Id);
            return View(employee_Guest);
        }

        // POST: EmployeeGuest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Employee_Id,Guest_Id")] Employee_Guest employee_Guest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_Guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", employee_Guest.Employee_Id);
            ViewBag.Guest_Id = new SelectList(db.Guests, "Id", "F_Name", employee_Guest.Guest_Id);
            return View(employee_Guest);
        }

        // GET: EmployeeGuest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Guest employee_Guest = db.Employee_Guest.Find(id);
            if (employee_Guest == null)
            {
                return HttpNotFound();
            }
            return View(employee_Guest);
        }

        // POST: EmployeeGuest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_Guest employee_Guest = db.Employee_Guest.Find(id);
            db.Employee_Guest.Remove(employee_Guest);
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

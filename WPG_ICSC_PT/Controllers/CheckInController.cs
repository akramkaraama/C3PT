 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BOL;

namespace WPG_ICSC_PT.Controllers
{
    public class CheckInController : Controller
    {
        private WPG_ConferenceEntities db = new WPG_ConferenceEntities();

        public ActionResult Index(string searchBy, string search, int? page)
        {
            if (searchBy == null || (searchBy == "All"))
            {
                return View(db.EmployeeGuests.Include(x => x.Employee).Include(x => x.Guest.Meeting).
                    Where(x => x.Guest.Meeting.MeetingStatus_id == 1).
                    OrderBy(x => x.Guest.F_Name).ToPagedList(page ?? 1, 15));
            }
            else
            {
                if (search == "")
                {
                    return View();
                }
                else
                {
                    if (searchBy == "Name")
                    {
                        return View(db.EmployeeGuests.Include(x => x.Employee).Include(x => x.Guest).
                            Where(x => x.Guest.Meeting.MeetingStatus_id == 1 && x.Guest.Company.Name == search).
                            OrderBy(x => x.Guest.F_Name).ToPagedList(page ?? 1, 15));
                    }
                    else //if (searchBy == "Email")
                    {
                        return View(db.EmployeeGuests.Include(x => x.Employee).Include(x => x.Guest).
                            Where(x => x.Guest.Meeting.MeetingStatus_id == 1 && x.Guest.Email.StartsWith(search)).
                            OrderBy(x => x.Guest.Email).ToPagedList(page ?? 1, 15));
                    }
                }                
            }            
        }

        public ActionResult CheckIn(int? guestId)
        {

            TempData["checkinmsg"] = "<script>alert('Guest Checked In Successfully!');</script>";
            return RedirectToAction("Index");
        }

        //GET: 
        //public ActionResult Index(string email)
        //{
        //    //var guests = db.Guests.Include(g => g.Company).Include(g => g.Meeting);

        //    var guest = db.Guests.Include(g => g.Company).Include(g => g.Meeting).Where(x => x.Email == email).FirstOrDefault();

        //    return View(guest);
        //}

        //[HttpPost]
        //public ActionResult GuestDetails(string email)
        //{
        //    var guest = db.Guests.Include(g => g.Company).Include(g => g.Meeting).Where(x => x.Email == email).FirstOrDefault();


        //if (Membership.ValidateUser(employee.Email, employee.Password))
        //{
        //    FormsAuthentication.SetAuthCookie(employee.Email, false);
        //    return RedirectToAction("Index", "Home");

        //    return RedirectToAction("Index", new RouteValueDictionary(
        //        new { Controller = "Home", Action = "Index", Id = employee.Id }));

        //}

        //TempData["Msg"] = "Login Failed, Please try again";
        //    return View(guest);
        //}

        //// GET: CheckIn
        //public ActionResult Index()
        //{
        //    var guests = db.Guests.Include(g => g.Company).Include(g => g.Meeting);
        //    return View(guests.ToList());
        //}

        //// GET: CheckIn/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Guest guest = db.Guests.Find(id);
        //    if (guest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(guest);
        //}

        //// GET: CheckIn/Create
        //public ActionResult Create()
        //{
        //    ViewBag.Company_id = new SelectList(db.Companies, "Id", "Name");
        //    ViewBag.Meeting_Id = new SelectList(db.Meetings, "Id", "Topic");
        //    return View();
        //}

        //// POST: CheckIn/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,F_Name,L_Name,Email,PhoneNumber,Company_id,Meeting_Id")] Guest guest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Guests.Add(guest);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Company_id = new SelectList(db.Companies, "Id", "Name", guest.Company_id);
        //    ViewBag.Meeting_Id = new SelectList(db.Meetings, "Id", "Topic", guest.Meeting_Id);
        //    return View(guest);
        //}

        //// GET: CheckIn/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Guest guest = db.Guests.Find(id);
        //    if (guest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Company_id = new SelectList(db.Companies, "Id", "Name", guest.Company_id);
        //    ViewBag.Meeting_Id = new SelectList(db.Meetings, "Id", "Topic", guest.Meeting_Id);
        //    return View(guest);
        //}

        //// POST: CheckIn/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,F_Name,L_Name,Email,PhoneNumber,Company_id,Meeting_Id")] Guest guest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(guest).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Company_id = new SelectList(db.Companies, "Id", "Name", guest.Company_id);
        //    ViewBag.Meeting_Id = new SelectList(db.Meetings, "Id", "Topic", guest.Meeting_Id);
        //    return View(guest);
        //}

        //// GET: CheckIn/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Guest guest = db.Guests.Find(id);
        //    if (guest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(guest);
        //}

        //// POST: CheckIn/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Guest guest = db.Guests.Find(id);
        //    db.Guests.Remove(guest);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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

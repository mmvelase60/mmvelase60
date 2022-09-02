using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FINALBRIGHTPROJECT.ViewModel;
using FINALBRIGHTPROJECT.ViewModel.BrightModel;

namespace FINALBRIGHTPROJECT.Controllers
{
    public class PAYMENTsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PAYMENTs
        public ActionResult Index()
        {
            var payment = db.payment.Include(p => p.Bookings);
            return View(payment.ToList());
        }

        // GET: PAYMENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT pAYMENT = db.payment.Find(id);
            if (pAYMENT == null)
            {
                return HttpNotFound();
            }
            return View(pAYMENT);
        }

        // GET: PAYMENTs/Create
        public ActionResult Create()
        {
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingId", "FirstName");
            return View();
        }

        // POST: PAYMENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseId,Username,Date,Time,Cost,PayStatus,Purchasetype,BookingID")] PAYMENT pAYMENT)
        {
            if (ModelState.IsValid)
            {
                db.payment.Add(pAYMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingID = new SelectList(db.Bookings, "BookingId", "FirstName", pAYMENT.BookingID);
            return View(pAYMENT);
        }

        // GET: PAYMENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT pAYMENT = db.payment.Find(id);
            if (pAYMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingId", "FirstName", pAYMENT.BookingID);
            return View(pAYMENT);
        }

        // POST: PAYMENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseId,Username,Date,Time,Cost,PayStatus,Purchasetype,BookingID")] PAYMENT pAYMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAYMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingId", "FirstName", pAYMENT.BookingID);
            return View(pAYMENT);
        }

        // GET: PAYMENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT pAYMENT = db.payment.Find(id);
            if (pAYMENT == null)
            {
                return HttpNotFound();
            }
            return View(pAYMENT);
        }

        // POST: PAYMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAYMENT pAYMENT = db.payment.Find(id);
            db.payment.Remove(pAYMENT);
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

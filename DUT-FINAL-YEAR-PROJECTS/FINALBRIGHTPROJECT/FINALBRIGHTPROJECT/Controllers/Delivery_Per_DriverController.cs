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
    public class Delivery_Per_DriverController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Delivery_Per_Driver
        public ActionResult Index()
        {
            var problem = (from a in db.Delivery_Per_Drivers
                           join b in db.DeliveryTickets on a.ticketID equals b.ticketID
                           join c in db.Drivers on a.DriverId equals c.DriverId
                           select new { a.ticketID, b.DeliveryAddress, b.Code, b.city, a.DriverId, c.DriverName, c.DriverEmail, a.deliveryStatus }).ToList();
            List<DriverTicketsVM> vmList = new List<DriverTicketsVM>();
            DriverTicketsVM vmObje = new DriverTicketsVM();




            foreach (var item in problem)
            {


                vmObje.ticketID = item.ticketID;
                vmObje.driverId = item.DriverId;
                vmObje.deliveryAddress = item.DeliveryAddress;
                vmObje.city = item.city;
                vmObje.code = item.Code;
                vmObje.driverName = item.DriverName;
                vmObje.driverEmail = item.DriverEmail;
                vmObje.deliveryStatus = item.deliveryStatus;

                vmList.Add(vmObje);

            }
            //var problem_per_technicians = db.problem_per_technicians.Include(p => p.ProblemTickets).Include(p => p.technicians);

            return View(vmList);

        }

        // GET: Delivery_Per_Driver/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery_Per_Driver delivery_Per_Driver = db.Delivery_Per_Drivers.Find(id);
            if (delivery_Per_Driver == null)
            {
                return HttpNotFound();
            }
            return View(delivery_Per_Driver);
        }

        // GET: Delivery_Per_Driver/Create
        public ActionResult Create()
        {
            ViewBag.ticketID = new SelectList(db.DeliveryTickets, "ticketID", "DeliveryAddress");
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "DriverName");
            return View();
        }

        // POST: Delivery_Per_Driver/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Delivery_Per_DriverId,ticketID,DriverId,deliveryStatus")] Delivery_Per_Driver delivery_Per_Driver)
        {
            if (ModelState.IsValid)
            {
                db.Delivery_Per_Drivers.Add(delivery_Per_Driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ticketID = new SelectList(db.DeliveryTickets, "ticketID", "DeliveryAddress", delivery_Per_Driver.ticketID);
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "DriverName", delivery_Per_Driver.DriverId);
            return View(delivery_Per_Driver);
        }

        // GET: Delivery_Per_Driver/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery_Per_Driver delivery_Per_Driver = db.Delivery_Per_Drivers.Find(id);
            if (delivery_Per_Driver == null)
            {
                return HttpNotFound();
            }
            ViewBag.ticketID = new SelectList(db.DeliveryTickets, "ticketID", "DeliveryAddress", delivery_Per_Driver.ticketID);
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "DriverName", delivery_Per_Driver.DriverId);
            return View(delivery_Per_Driver);
        }

        // POST: Delivery_Per_Driver/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Delivery_Per_DriverId,ticketID,DriverId,deliveryStatus")] Delivery_Per_Driver delivery_Per_Driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delivery_Per_Driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ticketID = new SelectList(db.DeliveryTickets, "ticketID", "DeliveryAddress", delivery_Per_Driver.ticketID);
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "DriverName", delivery_Per_Driver.DriverId);
            return View(delivery_Per_Driver);
        }

        // GET: Delivery_Per_Driver/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery_Per_Driver delivery_Per_Driver = db.Delivery_Per_Drivers.Find(id);
            if (delivery_Per_Driver == null)
            {
                return HttpNotFound();
            }
            return View(delivery_Per_Driver);
        }

        // POST: Delivery_Per_Driver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Delivery_Per_Driver delivery_Per_Driver = db.Delivery_Per_Drivers.Find(id);
            db.Delivery_Per_Drivers.Remove(delivery_Per_Driver);
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

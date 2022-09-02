using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using FINALBRIGHTPROJECT.ViewModel;
using FINALBRIGHTPROJECT.ViewModel.BrightModel;

namespace FINALBRIGHTPROJECT.Controllers
{
    public class DeliveryTicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeliveryTickets
        public ActionResult Index()
        {
            return View(db.DeliveryTickets.ToList());
        }

        // GET: DeliveryTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryTicket deliveryTicket = db.DeliveryTickets.Find(id);
            if (deliveryTicket == null)
            {
                return HttpNotFound();
            }
            return View(deliveryTicket);
        }

        // GET: DeliveryTickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ticketID,DeliveryAddress,city,Code,DeliveryDate,DeliveryTime,DateCollected,CollectTime,category,username")] DeliveryTicket deliveryTicket)
        {
            if (ModelState.IsValid)
            {
                deliveryTicket.username = User.Identity.GetUserName();
                deliveryTicket.status = "Waiting for status";
                db.DeliveryTickets.Add(deliveryTicket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryTicket);
        }
        public ActionResult ShowTickets()
        {
            string username = User.Identity.GetUserName();
            List<DeliveryTicketViewModel> pvmList = new List<DeliveryTicketViewModel>();

            var tent = (from ab in db.Drivers
                        where ab.DriverEmail == username
                        select ab.tentType).SingleOrDefault();

            var ticketsList = (from ab in db.DeliveryTickets
                               where ab.category == tent
                               select new { ab.DeliveryAddress, ab.city,ab.Code, ab.category, ab.username }).ToList();


            DeliveryTicketViewModel pvm = new DeliveryTicketViewModel();

            foreach (var item in ticketsList)
            {
                pvm.deliveryAddress = item.DeliveryAddress;
                pvm.city = item.city;
                pvm.code = item.Code;
                pvm.category = item.category;
                pvm.username = item.username;

                pvmList.Add(pvm);
            }



            return View(pvmList);
        }
   

    // GET: DeliveryTickets/Edit/5
    public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryTicket deliveryTicket = db.DeliveryTickets.Find(id);
            if (deliveryTicket == null)
            {
                return HttpNotFound();
            }
            return View(deliveryTicket);
        }

        // POST: DeliveryTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ticketID,DeliveryAddress,city,Code,DeliveryDate,DeliveryTime,DateCollected,CollectTime,category,username,status")] DeliveryTicket deliveryTicket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryTicket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryTicket);
        }

        // GET: DeliveryTickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryTicket deliveryTicket = db.DeliveryTickets.Find(id);
            if (deliveryTicket == null)
            {
                return HttpNotFound();
            }
            return View(deliveryTicket);
        }

        // POST: DeliveryTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryTicket deliveryTicket = db.DeliveryTickets.Find(id);
            db.DeliveryTickets.Remove(deliveryTicket);
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

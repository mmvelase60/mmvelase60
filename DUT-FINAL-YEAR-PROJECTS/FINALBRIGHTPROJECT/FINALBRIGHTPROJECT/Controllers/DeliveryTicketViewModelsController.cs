using FINALBRIGHTPROJECT.ViewModel;
using FINALBRIGHTPROJECT.ViewModel.BrightModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FINALBRIGHTPROJECT.Controllers
{
    public class DeliveryTicketViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeliveryTicketViewModels
        public ActionResult Index()
        {
            return View(db.DeliveryTicketViewModels.ToList());
        }

        // GET: DeliveryTicketViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryTicketViewModel deliveryTicketViewModel = db.DeliveryTicketViewModels.Find(id);
            if (deliveryTicketViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryTicketViewModel);
        }

        // GET: DeliveryTicketViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryTicketViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productId,description,category,username,ticketID")] DeliveryTicketViewModel deliveryTicketViewModel)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryTicketViewModels.Add(deliveryTicketViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryTicketViewModel);
        }

        // GET: DeliveryTicketViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryTicketViewModel deliveryTicketViewModel = db.DeliveryTicketViewModels.Find(id);
            if (deliveryTicketViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryTicketViewModel);
        }

        // POST: DeliveryTicketViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productId,description,category,username,ticketID")] DeliveryTicketViewModel deliveryTicketViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryTicketViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryTicketViewModel);
        }

        // GET: DeliveryTicketViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryTicketViewModel deliveryTicketViewModel = db.DeliveryTicketViewModels.Find(id);
            if (deliveryTicketViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryTicketViewModel);
        }

        // POST: DeliveryTicketViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryTicketViewModel deliveryTicketViewModel = db.DeliveryTicketViewModels.Find(id);
            db.DeliveryTicketViewModels.Remove(deliveryTicketViewModel);
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

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using FINALBRIGHTPROJECT.ViewModel;
using FINALBRIGHTPROJECT.ViewModel.BrightModel;

namespace FINALBRIGHTPROJECT.Controllers
{
    public class DriversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Drivers
        public ActionResult Index()
        {
            return View(db.Drivers.ToList());
        }

        // GET: Drivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // GET: Drivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverId,DriverName,DriverSurname,DriverEmail,tentType,DriverCell")] Driver driver)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.UserName = driver.DriverEmail;
                user.Email = driver.DriverEmail;
                user.EmailConfirmed = true;

                string userPWD = "123456";

                var chkUser = UserManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Driver");

                    db.Drivers.Add(driver);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Drivers");
                }
            }


            return View(driver);
        }

        // GET: Drivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverId,DriverName,DriverSurname,DriverEmail,tentType,DriverCell")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driver);
        }

        // GET: Drivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Driver driver = db.Drivers.Find(id);
            db.Drivers.Remove(driver);
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

using FINALBRIGHTPROJECT.ViewModel;
using FINALBRIGHTPROJECT.ViewModel.BrightModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FINALBRIGHTPROJECT.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult showtask()
        {
            //TaskViewModel TaskViewModel = new TaskViewModel();
            //List<TaskViewModel> listv = new List<TaskViewModel>();
            //var tasks = db.problem_per_technicians.Where(x => x.technicians.technicianEmail == User.Identity.Name).ToList();
            //foreach(var item in tasks)
            //{
            //    TaskViewModel.technicianId = item.technicianId;
            //    TaskViewModel.ticketID = item.ticketID;
            //    TaskViewModel.description = item.ProblemTickets.description;
            //    TaskViewModel.category= item.ProblemTickets.category;
            //    listv.Add(TaskViewModel);

            //}

            var list = (from pr in db.DeliveryTickets
                        join per in db.Delivery_Per_Drivers
                        on pr.ticketID equals per.ticketID
                        where per.drivers.DriverEmail == User.Identity.Name
                        select pr).ToList();
            return View(list);
        }
        public ActionResult Accept(int? id)
        {
            DeliveryTicket deliveryTicket = db.DeliveryTickets.Find(id);
            deliveryTicket.status = "Task Accepted";
            //db.ProblemTickets.Add(problemTicket);
            db.Entry(deliveryTicket).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("showtask");
        }
        public ActionResult Complete(int? id)
        {

            DeliveryTicket deliveryTicket = db.DeliveryTickets.Find(id);
            deliveryTicket.status = "Task completed";
            //db.ProblemTickets.Add(problemTicket);
            db.Entry(deliveryTicket).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("showtask");
        }

        public ActionResult assigntask(int? id, int? idt)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            DeliveryTicket deliveryTicket = db.DeliveryTickets.Find(id);
            Driver drivers = db.Drivers.Find(idt);

            TaskViewModel TaskViewModel = new TaskViewModel();

            TaskViewModel.ticketID = deliveryTicket.ticketID;
            TaskViewModel.username = deliveryTicket.username;
            TaskViewModel.DeliveryAddress = deliveryTicket.DeliveryAddress;
            TaskViewModel.city = deliveryTicket.city;
            TaskViewModel.Code = deliveryTicket.Code;
            TaskViewModel.category = deliveryTicket.category;

            TaskViewModel.DrviverId = drivers.DriverId;
            TaskViewModel.DriverName = drivers.DriverName;
            TaskViewModel.DriverSurname = drivers.DriverSurname;
            TaskViewModel.TentType = drivers.tentType;
            TaskViewModel.DriverEmail = drivers.DriverEmail;
            TaskViewModel.DriverCell = drivers.DriverCell;
            TaskViewModel.Job = db.Delivery_Per_Drivers.Where(x => x.DriverId == drivers.DriverId).Count();

            ViewBag.driverId = new SelectList(db.Drivers, "DrviverId", "DriverEmail", TaskViewModel.DrviverId);
            if (deliveryTicket == null)
            {
                return HttpNotFound();
            }
            return View(TaskViewModel);
        }

        // POST: ProblemTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult assigntask([Bind(Include = "ticketID,DrviverId,DeliveryAddress,Code, city category,username")] TaskViewModel TaskViewModel)
        {
            Delivery_Per_Driver delivery_Per_Driver = new Delivery_Per_Driver();

            if (ModelState.IsValid)
            {
                delivery_Per_Driver.DriverId = TaskViewModel.DrviverId;
                delivery_Per_Driver.ticketID = TaskViewModel.ticketID;
                db.Delivery_Per_Drivers.Add(delivery_Per_Driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(TaskViewModel);
        }

    }
}
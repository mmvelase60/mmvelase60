using FINALBRIGHTPROJECT.ViewModel;
using FINALBRIGHTPROJECT.ViewModel.BrightModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FINALBRIGHTPROJECT.Controllers
{
    public class DriverTicketController : Controller
    {
        // GET: DriverTicket
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            return View(db.Delivery_Per_Drivers.ToList());
        }

        public ActionResult TicketPer()
        {

            var username = User.Identity.GetUserName() + "@gmail.com";

            var getID = (from b in db.Drivers
                         where b.DriverEmail == username
                         select b.DriverId).Single();

            var tickets = (from a in db.Delivery_Per_Drivers
                           where getID == a.DriverId
                           select new { a.DriverId, a.ticketID, a.deliveryStatus, a.city,a.code}).ToList();

            List<DriverTicketsVM> driveList = new List<DriverTicketsVM>();
            DriverTicketsVM ppt = new DriverTicketsVM();


            foreach (var item in tickets)
            {
                ppt.driverId = item.DriverId;
                ppt.ticketID = item.ticketID;
                ppt.city = item.city;
                ppt.code = item.code;
                ppt.deliveryStatus = item.deliveryStatus;
                

                driveList.Add(ppt);
            }

            return View(driveList);

        }
    }
}
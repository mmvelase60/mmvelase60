using FINALBRIGHTPROJECT.ViewModel;
using FINALBRIGHTPROJECT.ViewModel.BrightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FINALBRIGHTPROJECT.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult Index()
        {
            return View();
        }
        ApplicationDbContext Db = new ApplicationDbContext();
        const string PromoCode = "50020";

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var booking = new Booking();
            TryUpdateModel(booking);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(booking);
                }
                else
                {
                    booking.Username = User.Identity.Name;
                    booking.OrderDate = DateTime.Now;


                    Db.Bookings.Add(booking);
                    Db.SaveChanges();

                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(booking);

                    return RedirectToAction("Complete",
                        new { id = booking.BookingId });
                }
            }
            catch
            {

                return View(booking);
            }
        }

        public ActionResult Complete(int id)
        {

            bool isValid = Db.Bookings.Any(
                o => o.BookingId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
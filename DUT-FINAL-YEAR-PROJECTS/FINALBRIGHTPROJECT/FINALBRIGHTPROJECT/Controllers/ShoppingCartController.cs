using FINALBRIGHTPROJECT.ViewModel;
using FINALBRIGHTPROJECT.ViewModel.BrightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FINALBRIGHTPROJECT.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext Db = new ApplicationDbContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var viewModel = new ViewModel.ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {

            var addedItem = Db.Items.Single(item => item.TentId == id);


            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedItem);


            return RedirectToAction("Index");
        }
        public ActionResult CancleItem(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            var itemName = Db.Carts.Single(item => item.RecordId == id);

            // Remove from cart
            cart.CancleItem(id);


            return RedirectToAction("Index", "ShoppingCart");
        }
        public ActionResult EmptyCart()
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation


            // Remove from cart
            cart.EmptyCart();


            return RedirectToAction("Index", "ShoppingCart");
        }
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {

            var cart = ShoppingCart.GetCart(this.HttpContext);


            string itemName = Db.Carts.Single(item => item.RecordId == id).Item.TentName;


            int itemCount = cart.RemoveFromCart(id);


            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(itemName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}
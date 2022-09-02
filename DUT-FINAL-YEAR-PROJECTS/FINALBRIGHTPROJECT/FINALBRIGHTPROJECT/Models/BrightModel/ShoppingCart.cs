using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class ShoppingCart
    {
        ApplicationDbContext Db = new ApplicationDbContext();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(System.Web.Mvc.Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Items item)
        {

            var cartItem = Db.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.TentId == item.TentId);

            if (cartItem == null)
            {

                cartItem = new Cart
                {
                    TentId = item.TentId,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                Db.Carts.Add(cartItem);
            }
            else
            {

                cartItem.Count++;
            }

            Db.SaveChanges();
        }
        public void CancleItem(int id)
        {
            Cart c = new Cart();
            var s = Db.Carts.ToList().Find(x => x.RecordId == id);
            var cartItem = Db.Carts.Single(
                cart => cart.CartId == ShoppingCartId
                && cart.RecordId == id);


            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    Db.Carts.Remove(cartItem);
                }
                else
                {
                    Db.Carts.Remove(cartItem);
                }

                var cart = Db.Items.ToList().Where(x => x.TentId == cartItem.lid);
                foreach (var item in cart)
                {
                    item.Quantity = item.Quantity + cartItem.Count;
                    Db.Items.Attach(item);
                    Db.Entry(item).Property(x => x.Quantity).IsModified = true;
                }
                // Save changes
                Db.SaveChanges();
            }
        }


        public int RemoveFromCart(int id)
        {
            var s = Db.Carts.ToList().Find(x => x.RecordId == id);
            var cartItem = Db.Carts.Single(
                 cart => cart.CartId == ShoppingCartId
                 && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    Db.Carts.Remove(cartItem);
                }
                var cart = Db.Items.ToList().Where(x => x.TentId == cartItem.lid);
                foreach (var item in cart)
                {
                    item.Quantity = item.Quantity + 1;
                    Db.Items.Attach(item);
                    Db.Entry(item).Property(x => x.Quantity).IsModified = true;
                }
                Db.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = Db.Carts.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                Db.Carts.Remove(cartItem);
            }

            Db.SaveChanges();
        }
        public List<Cart> GetCartItems()
        {
            return Db.Carts.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }
        public int GetCount()
        {

            int? count = (from cartItems in Db.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }

        public decimal GetTotal()
        {

            decimal? total = (from cartItems in Db.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count *
                              cartItems.Item.TentPrice).Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(Booking booking)
        {
            decimal itemTotal = 0;

            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var itemDetail = new ItemDetails
                {
                    TentId = item.TentId,
                    BookingId = booking.BookingId,
                    UnitPrice = item.Item.TentPrice,
                    Quantity = item.Count
                };

                itemTotal += (item.Count * item.Item.TentPrice);

                Db.ItemDetails.Add(itemDetail);

            }

            booking.Total = itemTotal;


            Db.SaveChanges();

            EmptyCart();

            return booking.BookingId;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {

                    Guid tempCartId = Guid.NewGuid();

                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        public void MigrateCart(string Email)
        {
            var shoppingCart = Db.Carts.Where(
                c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = Email;
            }
            Db.SaveChanges();

        }

    }
}
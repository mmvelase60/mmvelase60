using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using FINALBRIGHTPROJECT.ViewModel.BrightModel;

namespace FINALBRIGHTPROJECT.ViewModel
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.PAYMENT> payment { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.TimeSlots> timeslots { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.Employee> employee { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.InvoiceViewModel> invoiceViewModel { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.Comment> comment { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BookingViewModel> bookingViewModel { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.DeliveryViewModel> deliveringViewModel { get; set; }
         public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.FeedBack> Feedbacks { get; set; }
        public DbSet<IdentityUserRole> UserInRole { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.OWNER> owner { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.PayFastModel> PayFastModels { get; set; }
         public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.FeedbackViewModel> FeedbackViewModels { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.Driver> Drivers { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.Delivery_Per_Driver> Delivery_Per_Drivers { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.DeliveryTicket> DeliveryTickets { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.TaskViewModel> TaskViewModels { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.DriverTicketsVM> DriverTicketVMS { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.RolesView> RolesViews { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.UsersView> UsersViews { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.DeliveryTicketViewModel> DeliveryTicketViewModels { get; set; }
        public DbSet<FINALBRIGHTPROJECT.ViewModel.BrightModel.Purchase> Purchase { get; set; }
        //Role Management
        //public DbSet<IdentityUserRole> UserInRoles { get; set; }
        // public DbSet<ApplicationUser> appUsers { get; set; }

        public DbSet<ApplicationRole> appRoles { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ItemDetails> ItemDetails { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public System.Data.Entity.DbSet<FINALBRIGHTPROJECT.ViewModel.ShoppingCartViewModel> ShoppingCartViewModels { get; set; }
    }
}
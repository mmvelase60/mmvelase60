using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class ItemDetails
    {
        [Key]
        public int itemDetailId { get; set; }
        public int BookingId { get; set; }
        public int TentId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Items Item { get; set; }
        public virtual Booking Bookings { get; set; }

    }
}
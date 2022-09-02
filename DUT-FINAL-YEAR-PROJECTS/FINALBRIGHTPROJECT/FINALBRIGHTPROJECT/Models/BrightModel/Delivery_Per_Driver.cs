using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class Delivery_Per_Driver
    {
        public int Delivery_Per_DriverId { get; set; }
        public int ticketID { get; set; }
        public virtual DeliveryTicket DeliveryTickets { get; set; }
        public int DriverId { get; set; }
        public virtual Driver drivers { get; set; }
        public string city { get; set; }
        public string code { get; set; }
        public string deliveryStatus { get; set; }
    }
}
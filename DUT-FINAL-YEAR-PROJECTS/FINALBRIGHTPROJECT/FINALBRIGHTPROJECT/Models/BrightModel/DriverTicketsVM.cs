using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class DriverTicketsVM
    {
        [Key]
        public int vmID { get; set; }
        public int driverId { get; set; }
        public int ticketID { get; set; }   
        public string city { get; set; }
        public string code { get; set; }
        public virtual DeliveryTicket DeliveryTickets { get; set; }
        public string deliveryAddress { get; set; }
        public string driverName { get; set; }
        public string driverEmail { get; set; }
        public string deliveryStatus { get; set; }
    }
}
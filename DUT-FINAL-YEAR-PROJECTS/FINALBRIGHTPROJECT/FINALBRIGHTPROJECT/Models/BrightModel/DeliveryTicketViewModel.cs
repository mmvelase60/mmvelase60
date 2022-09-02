using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class DeliveryTicketViewModel
    {
        [Key]
        public int productId { get; set; }
        public int ticketID { get; set; }
        public string deliveryAddress { get; set; }
        public string city { get; set; }
        public string code { get; set; }
        public virtual DeliveryTicket DeliveryTickets { get; set; }
        public string category { get; set; }
        public string username { get; set; }
    
    }
}
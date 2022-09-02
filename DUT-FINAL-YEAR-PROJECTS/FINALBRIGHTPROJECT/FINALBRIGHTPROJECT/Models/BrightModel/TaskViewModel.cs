using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class TaskViewModel
    {
        [Key]
        public int taskId { get; set; }
        public string DeliveryAddress { get; set; }
        public string city { get; set; }
        public string Code { get; set; }
        [DisplayName("Type of Tents")]
        public string category { get; set; }
        [DisplayName("Customer Name")]
        public string username { get; set; }
        public int ticketID { get; set; }
        public virtual DeliveryTicket DeliveryTickets { get; set; }

        public int DrviverId { get; set; }
        public virtual Driver Drivers { get; set; }
        public string DriverName { get; set; }
        public string DriverSurname { get; set; }
        public string DriverEmail { get; set; }
        public string TentType { get; set; }
        public string DriverCell { get; set; }
        [DisplayName("Task(s)")]
        public int delivery { get; set; }
        public int Job { get; set; }
    }
}
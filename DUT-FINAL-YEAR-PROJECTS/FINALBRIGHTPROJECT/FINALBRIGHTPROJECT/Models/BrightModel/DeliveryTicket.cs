using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class DeliveryTicket
    {
        [Key]
        [DisplayName("Ticket ID")]

        public int ticketID { get; set; }
        [Required]
        [DisplayName("Delivery Address")]
        [StringLength(500)]
        public string DeliveryAddress { get; set; }
        [Required]
        [DisplayName("City")]
        [StringLength(500)]
        public string city { get; set; }
        [Required]
        [DisplayName("Code")]
        [StringLength(4, ErrorMessage="Code cannot have more than 4 characters")]
        public string Code { get; set; }
        [Required]
        [DisplayName("Delivery Date ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm-dd-yyyy", ApplyFormatInEditMode =true)]
        public DateTime DeliveryDate { get; set; }
        [Required]
        [DisplayName("Delivery Time ")]
        [DataType(DataType.Time)]
        public DateTime DeliveryTime { get; set; }
        [Required]
        [DisplayName("Date Collected ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm-dd-yyyy", ApplyFormatInEditMode = true)]
        public DateTime DateCollected { get; set; }
        [Required]
        [DisplayName("Collected Time ")]
        [DataType(DataType.Time)]
        public DateTime CollectTime { get; set; }
        //DropDownlist
        [Required]
        [DisplayName("Type of Tent ")]
        public string category { get; set; }

        //GetItFromTheCustomerThatLoggedIn
        public string username { get; set; }
        public string status { get; set; }
        public enum Category
        {
            Allidin,
            Marquees,
            Frame,

        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class PAYMENT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseId { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [ScaffoldColumn(false)]
        public decimal Cost { get; set; }
        public string PayStatus { get; set; }
        [Display(Name = "Purchase Type")]
        public string Purchasetype { get; set; }
        public int BookingID { get; set; }
        public virtual Booking Bookings { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PurchaseId { get; set; }
        public string Username { get; set; }
        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }
        public decimal Cost { get; set; }
        public string Status { get; set; }
        [Display(Name = "Purchase Type")]
        public string Purchasetype { get; set; }
    }
}
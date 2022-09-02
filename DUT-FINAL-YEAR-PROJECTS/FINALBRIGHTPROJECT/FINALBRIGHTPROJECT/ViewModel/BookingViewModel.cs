using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace FINALBRIGHTPROJECT.ViewModel
{
    public class BookingViewModel
    {
        [Key]
        [DisplayName("ID")]

        public int BookViewID { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [DisplayName("LastName")]
        [StringLength(50)]
        public string BLastName { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        [DisplayName("Surname")]
        [StringLength(50)]
        public string BSurname { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]

        [Required(ErrorMessage = "cellphone number is required.")]
        [DisplayName("Phone No:")]
        [StringLength(10)]
        public string BCellNumber { get; set; }
        [Required(ErrorMessage = "Your Address is required")]
        [DisplayName("Addres")]
        [StringLength(60)]
        public string BookAddress { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = " Date ")]
        public DateTime BDueDateView { get; set; }

        [DataType(DataType.Time)]
        [DisplayName("Time")]
        public DateTime BDueTimeView { get; set; }

        [DisplayName("Type")]
        public string TypeTent { get; set; }
        [DisplayName("Days:")]
        [Required(ErrorMessage = "Number of days, is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public int BNumOfDaysView { get; set; }
        [DisplayName("Size")]
        public string tentSize { get; set; }
        [Display(Name = "QTY")]
        [Required(ErrorMessage = "Quantity is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public int BookQuantityView { get; set; }
        [DisplayName("Total")]
        public decimal Cost { get; set; }
        [DisplayName("Total")]
        public decimal BTotalPriceView { get; set; }
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please Enter valid email")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string BEmailAddress { get; set; }

        [Required(ErrorMessage = "Please Enter RSA ID or Drivers Licence for Identification")]
        [Display(Name = "RSA ID")]
        [StringLength(13, ErrorMessage = "ID cannot have more than 13 characters")]
        public string BIdentityNumber { get; set; }
        [Display(Name = "Status")]
        public string Bstatus { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class Booking
    {
        [Key]
        [ScaffoldColumn(false)]
        public int BookingId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm-dd-yyyy", ApplyFormatInEditMode = true)]
        public DateTime ReserveDate { get; set; }
        [Required]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }
        [Required]
        [StringLength(40)]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Range(0, 9999999999, ErrorMessage = "Only 10 numbers allowed")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Only number allowed")]
        public string customerCellNo { get; set; }
        [Required]
        [DisplayName("Tent Type")]
        public string TentType { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int NumOfDays { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm-dd-yyyy", ApplyFormatInEditMode = true)]
        public DateTime DateCollected { get; set; }
        [DataType(DataType.Time)]
        // [DisplayFormat(DataFormatString = "{0:mm-dd-yyyy", ApplyFormatInEditMode = true)]
        public DateTime TimeCollected { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        public string Username { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }



    }
}
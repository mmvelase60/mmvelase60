using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class Driver
    {
        [Key]
        [DisplayName("Drivers ID")]
        public int DriverId { get; set; }
        [StringLength(100)]
        [Required]
        [DisplayName("Driver Name")]
        public string DriverName { get; set; }
        [StringLength(100)]
        [Required]
        [DisplayName("Driver Surname")]
        public string DriverSurname { get; set; }
        [DisplayName("Driver Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        [Required]
        public string DriverEmail { get; set; }
        //DropDownList
        [DisplayName("Tent Type")]
        [StringLength(100)]
        [Required]
        public string tentType { get; set; }
        [DisplayName("Cellnumber")]
        [StringLength(10)]
        [Required(ErrorMessage = "Please input the number")]
        [DataType(DataType.PhoneNumber)]
        //[Range(1000000000, 9999999999, ErrorMessage = "Only 10 numbers allowed")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "No characters allowed")]
        public string DriverCell { get; set; }
        public enum TentType
        {
            Allidin ,
            Marquees,
            Frame,

        }
    }
}
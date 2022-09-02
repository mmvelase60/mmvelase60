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
    public class OWNER
    {
        [Key]
        public int ownerID { get; set; }
        [DisplayName("Owner FirstName")]
        public string ownerFirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [DisplayName("Owner LastName")]
        [StringLength(50)]
        public string ownerLastName { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        [DisplayName("Surname")]
        [StringLength(50)]
        public string ownerSurname { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Required(ErrorMessage = "cellphone number is required.")]
        [DisplayName("OwnerPhone No:")]
        [StringLength(10)]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Your Address is required")]
        [DisplayName("Owner Addres")]
        [StringLength(60)]
        public string OwnerAddress { get; set; }
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please Enter valid email")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string EmailAddress { get; set; }
    


    }
}
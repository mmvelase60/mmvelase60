using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace FINALBRIGHTPROJECT.Validations
{
    public class addroles2usercs
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,1000}$", ErrorMessage = "Numbers and special characters are not allowed.")]
        public string Role { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
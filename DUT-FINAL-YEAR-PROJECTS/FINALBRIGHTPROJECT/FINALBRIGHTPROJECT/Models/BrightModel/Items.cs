using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TentId { get; set; }
        [Required]
        [Display(Name = "Tent Name")]
        public string TentName { get; set; }
        [Required]
        [Display(Name = "Tent Size")]
        public string TentSize { get; set; }
        // [Required]
        [Display(Name = "Tent Price")]
        public decimal TentPrice { get; set; }

        [Display(Name = "Select Category")]
        [ScaffoldColumn(false)]
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Categories { get; set; }

        [Display(Name = " Upload Tent Image ")]
        public byte[] TentImage { get; set; }


    }
}
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
    public class FeedBack
    {
        [Key]
        public int Id { get; set; }

        public int? Answer { get; set; }
        [StringLength(500)]

        public string Comment { get; set; }
        [StringLength(100)]

        public string FullName { get; set; }
        [StringLength(255)]

        public string Email { get; set; }
    }
}
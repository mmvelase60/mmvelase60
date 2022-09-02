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
    public class Answer
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Css { get; set; }
    }
}
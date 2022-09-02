using FINALBRIGHTPROJECT.ViewModel.BrightModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALBRIGHTPROJECT.ViewModel
{
    public class FeedbackViewModel
    {
        [Key]
        public string Comment { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public int? Select { get; set; }

        public List<Answer> Answers { get; set; }
    }
}

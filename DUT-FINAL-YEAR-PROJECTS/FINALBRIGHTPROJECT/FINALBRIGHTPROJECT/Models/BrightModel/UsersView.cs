﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class UsersView
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}
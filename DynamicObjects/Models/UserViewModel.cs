﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicObjects.Models
{
    public class UserViewModel
    {
        [Display(Name="User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

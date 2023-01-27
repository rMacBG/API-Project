﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Models.Models.AuthRequests
{
    public class RegisterVModel
    {
        [Required(ErrorMessage = "Username Required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "E-mail Required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
       
    }
}

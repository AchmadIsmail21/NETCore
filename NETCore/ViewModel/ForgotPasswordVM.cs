using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.ViewModel
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.ViewModel
{
    public class ChangePassVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Minimal Password 6 and Maximal Password 50", MinimumLength = 6)]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Minimal Password 6 and Maximal Password 50", MinimumLength = 6)]
        public string NewPassword { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Minimal Password 6 and Maximal Password 50", MinimumLength = 6)]
        public string ConfirmPassword { get; set; }
    }
}

using NETCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.ViewModel
{
    public class RegisterVM
    {
        [Required]
        public string NIK { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public enum Gender
        {
            Male,
            Female
        }
        [Required]
        public Gender gender { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Minimal Password 6 and Maximal Password 50", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string GPA { get; set; }
        [Required]
        public int UniversityId { get; set; }
        public ICollection<AccountRole> AccountRoles { get; set; }
    }
}

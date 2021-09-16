using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    [Table("tb_m_persons")]
    public class Person
    {
        [Key] //anotasi primary key
        [Required(ErrorMessage = "Please Enter NIK")]
        public string NIK { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Number Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Enter Your Birth Date")]
        public DateTime BirthDate { get; set; }

        public int Salary { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }

        public enum Gender { 
            Male,
            Female
        }
        
        public Gender gender { get; set; }

        public virtual Account Account { get; set; }

    }
}

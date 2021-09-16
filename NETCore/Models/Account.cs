using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using System.Threading.Tasks;

namespace NETCore.Models
{
    [Table("tb_tr_accounts")]
    public class Account
    {
        [Key]
        [Required(ErrorMessage = "Please Enter NIK")]
        public string NIK { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(50, ErrorMessage = "Minimal Password 6 and Maximal Password 50", MinimumLength = 6)]
        public string Password { get; set; }

        [JsonIgnore]
        public virtual Person Person { get; set; }
        [JsonIgnore]
        public virtual Profiling Profiling { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountRole> AccountRoles { get; set; }

    }
}

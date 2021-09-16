using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    [Table("tb_m_role")]
    public class Role
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        //[Required]
        [JsonIgnore]
        public virtual ICollection<AccountRole> AccountRoles { get; set;}
    }
}

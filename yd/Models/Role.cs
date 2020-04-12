using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yd.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
    }
}

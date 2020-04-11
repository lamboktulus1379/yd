using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace yd.Models
{
    public class YD
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName="nvarchar(100)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Number { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yd.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int NumberOfRows { get; set; }
        [Required]
        public int NumberOfColumns { get; set; }
        public ICollection<Table> Tables { get; set; }        
    }
}

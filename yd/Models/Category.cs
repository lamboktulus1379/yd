using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yd.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int parentId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

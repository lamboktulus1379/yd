using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yd.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int parentId  { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yd.Models
{
    public class YDContext : DbContext
    {
        public YDContext(DbContextOptions<YDContext> options) : base(options)
        {

        }
        public DbSet<YD> YD { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yd.Models;

namespace Gra.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GraContext(serviceProvider.GetRequiredService<DbContextOptions<GraContext>>()))
            {
                if (context.ProductCategories.Any())
                {
                    return;
                }
                context.ProductCategories.AddRange(
                    new ProductCategory
                    {
                        Name = "Buku"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}

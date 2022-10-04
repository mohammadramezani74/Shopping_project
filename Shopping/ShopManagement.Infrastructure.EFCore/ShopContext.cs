using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductActegoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {
                
        }
        public DbSet<ProductCategory> productCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(ProductCategory).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

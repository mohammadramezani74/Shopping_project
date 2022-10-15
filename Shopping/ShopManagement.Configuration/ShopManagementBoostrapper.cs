using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductActegoryAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;


namespace ShopManagement.Configuration
{
    public static class ShopManagementBoostrapper
    {
        public static IServiceCollection configure(this IServiceCollection services, IConfiguration configuration)

        {
            services.AddTransient<IproductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductCategoryRepository,ProductCategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddDbContext<ShopContext>(x => x.UseSqlServer(configuration.GetConnectionString("LampshadeConnection")));

            return services;
        }
    }
}

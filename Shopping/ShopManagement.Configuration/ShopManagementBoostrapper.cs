﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductActegoryAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;


namespace ShopManagement.Configuration
{
    public static class ShopManagementBoostrapper
    {
        public static IServiceCollection configure(this IServiceCollection services, IConfiguration configuration)

        {
            services.AddTransient<IproductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository,ProductCategoryRepository>();
            services.AddDbContext<ShopContext>(x => x.UseSqlServer(configuration.GetConnectionString("LampshadeConnection")));

            return services;
        }
    }
}
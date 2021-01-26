using Microsoft.Extensions.DependencyInjection;
using MVCShop.Repositories;
using MVCShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Services
{
    public static class AddServices
    {
        public static IServiceCollection AddToysService(this IServiceCollection services)
        {
            services.AddScoped<CatalogeService>();
            services.AddScoped<AdminService>();
            services.AddScoped<ToyRepository>();
            services.AddScoped<BasketService>();
            return services;
        }
    }
}

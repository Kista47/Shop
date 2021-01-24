using Microsoft.Extensions.DependencyInjection;
using MVCControllers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCControllers.Services
{
    public static class AddServices
    {
        
        public static IServiceCollection AddToysService(this IServiceCollection services)
        {
            services.AddScoped<CatalogeService>();
            services.AddScoped<AdminService>();
            services.AddScoped<ToyRepository>();
            return services;
        }
    }
}

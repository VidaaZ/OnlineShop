using Microsoft.Extensions.DependencyInjection;
using Domain.Service.Product;
using Business.Service.Product;
using Microsoft.Extensions.Configuration;
using DataAccess;
using DataAccess.Repository.Product;
using Domain.Repository;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServiceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDataAccessServices(configuration);   // From DataAccess
            services.AddApplicationServices();                    // Repositories
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();


            return services;
        }
    }
}

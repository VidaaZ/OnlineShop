using Business.Service.Product;
using DataAccess;
using DataAccess.Repository.Product;
using Domain.Repository.Product;
using Domain.Service.Product;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServiceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDataAccessServices(configuration);
            services.AddApplicationServices();


            #region Service

            services.AddScoped<IProductService, ProductService>();

            #endregion

            #region Repository

            services.AddScoped<IProductRepository, ProductRepository>();

            #endregion

            return services;
        }
    }
}

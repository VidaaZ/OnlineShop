using DataAccess.Repository.Product;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class AppRepositoryContainer
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}

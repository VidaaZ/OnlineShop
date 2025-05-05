using Business.Service.Product;
using Domain.Service.Product;
using Microsoft.Extensions.DependencyInjection;


namespace Business
{
    public static class AppServiceContainer
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}

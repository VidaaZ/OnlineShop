using Business.Service.Product;
using Business.Service.SignupService;
using Domain.Service.Product;
using Domain.Service.Signup;
using Microsoft.Extensions.DependencyInjection;


namespace Business
{
    public static class AppServiceContainer
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<ISignUpService, SignUpService>();
        }
    }
}

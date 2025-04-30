using Domain.Entity.Product;

namespace Domain.Repository.Product{
    public interface IProductRepository
    {
        Task<IEnumerable<Domain.Entity.Product.Product>> GetProductsAsync();
        void DeleteProduct(Entity.Product.Product product);
        Task<Domain.Entity.Product.Product> GetProductById(int id);
        Task<Domain.Entity.Product.Product> CreateProductAsync(Domain.Entity.Product.Product product);
        Task<Domain.Entity.Product.Product> UpdateProductRepository(Domain.Entity.Product.Product product);
        Task<IEnumerable<Domain.Entity.Product.Product>> SearchProductsAsync(string productName, string categoryName);
        Task<List<Domain.Entity.Product.Product>> GetAllPricesByIdAsync(List<int> productIds);
        Task<string> CreateAllProductImagesByIdAsync(ProductImage productImages);
    }
}

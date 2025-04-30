using Domain.Entity.Product;

namespace Domain.Repository{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        void DeleteProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductRepository(Product product);
        Task<IEnumerable<Product>> SearchProductsAsync(string productName, string categoryName);
        Task<List<Product>> GetAllPricesByIdAsync(List<int> productIds);
        Task<string> CreateAllProductImagesByIdAsync(ProductImage productImages);
    }
}

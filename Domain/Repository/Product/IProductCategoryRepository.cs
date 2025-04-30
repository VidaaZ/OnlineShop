using Domain.Entity.Product;

namespace Domain.Repository.Product
{
    public interface IProductCategoryRepository
    {
        Task CreateProductCategory(ProductCategory entity);
        Task<ProductCategory> UpdateProductCategoryAsync(ProductCategory entity);
        Task DeleteProductCategoryAsync(ProductCategory productCategory);
        Task<ProductCategory> GetProductCategoryAsync(string name);
        Task<ProductCategory> GetProductCategoryByIdAsync(int id);
        Task DeleteProductCategoryAsync(int id);
        Task<List<ProductCategory>> GetAllProductCategoriesAsync();
    }
}

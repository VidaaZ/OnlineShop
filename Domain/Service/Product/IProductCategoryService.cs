using Domain.Dto.Product;

namespace Domain.Service.Product
{
    public interface IProductCategoryService
    {
        Task DeleteProductCategoryAsync(int id);
        Task CreateProductCategoryAsync(ProductCategoryRequestDto dto);
        Task UpdateProductCategoryAsync(ProductCategoryRequestDto dto);
        Task<List<ProductCategoryRequestDto>> GetProductCategoryAsync();
    }
}
using Domain.Dto.Product;
using Domain.Mapper.Product;
using Domain.Repository.Product;
using Domain.Service.Product;

namespace Business.Service.Product
{
    internal class ProductCategoryService : IProductCategoryService
    {
        #region Properties

        private readonly IProductCategoryRepository _productCategoryRepository;

        #endregion

        #region Constructor

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        #endregion

        #region Methods

        public async Task CreateProductCategoryAsync(ProductCategoryRequestDto dto)
        {
            bool isAvailable = await IsProductCategoryAvailable(dto.Name);
            if (!isAvailable)
            {
                var entity = ProductCategoryMapper.ToEntity(dto);
                await _productCategoryRepository.CreateProductCategory(entity);
            }
            else
                throw new Exception("douplicate");
        }

        private async Task<bool> IsProductCategoryAvailable(string name) =>
            false;

        public async Task DeleteProductCategoryAsync(int id)
        {
            var user = await _productCategoryRepository.GetProductCategoryByIdAsync(id);

            if (user is null)
                throw new Exception("User not found.");

            await _productCategoryRepository.DeleteProductCategoryAsync(id);
        }
        public async Task<List<ProductCategoryRequestDto>> GetProductCategoryAsync()
        {

            var categories = await _productCategoryRepository.GetAllProductCategoriesAsync();

            var result = categories.Select(category => new ProductCategoryRequestDto
            {
                Name = category.Name,
                CreateDate = category.CreatedDate
            }).ToList();

            return result;
        }

        public async Task UpdateProductCategoryAsync(ProductCategoryRequestDto dto)
        {
            var productCategory = await _productCategoryRepository.GetProductCategoryAsync(dto.Name);

            if (productCategory is null)
                throw new Exception("User not found.");

            productCategory = ProductCategoryMapper.ToEntity(dto);
            await _productCategoryRepository.UpdateProductCategoryAsync(productCategory);
        }

        #endregion
    }
}

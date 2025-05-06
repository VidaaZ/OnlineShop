using Domain.Dto.Product;
using Domain.Mapper.Product;
using Domain.Repository;
using Domain.Service.Product;

namespace Business.Service.Product
{
    public class ProductService : IProductService
    {
        #region Properties

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Methods
        public async Task<string> CreateAllProductImagesByIdAsync(ProductImageDto productImage)
        {

            if (productImage is null)
                throw new ArgumentException("ProductImage is null");

            var product = _productRepository.GetProductById(productImage.ProductId);

            if (product is null)
                throw new ArgumentException("Product is not found!");

            int processorCount = Environment.ProcessorCount;

            var pararllelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = processorCount
            };

            var tasks = new List<Task>();

            Parallel.ForEach(productImage.ImageDatas, pararllelOptions, imageData =>
            {
                var task = Task.Run(async () =>
                {
                    using (var ms = new MemoryStream())
                    {
                        await imageData.CopyToAsync(ms);

                        var productImageEntity = ProductMapper.ToEntity(productImage, ms);

                        await _productRepository.CreateAllProductImagesByIdAsync(productImageEntity);

                    }
                });

                tasks.Add(task);
            });
            await Task.WhenAll();

            return "Success";
        }

        public async Task<ProductResponseDto> CreateProductAsync(ProductRequestDto dto)
        {
            try
            {
                var product = ProductMapper.ToEntity(dto);
                var createdProduct = await _productRepository.CreateProductAsync(product);
                return ProductMapper.ToProductResponseDto(createdProduct);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while creating the product.", ex);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                var product = _productRepository.GetProductById(id).Result;

                if (product == null)
                    throw new KeyNotFoundException("Product with the specified ID not found.");

                _productRepository.DeleteProduct(product);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while deleting the product.", ex);
            }
        }

        public async Task<List<double>> GetPriceAsync(List<int> productIds)
        {
            var prices = await _productRepository.GetAllPricesByIdAsync(productIds);
            return prices.Select(item => item.Price).ToList();
        }

        public async Task<IEnumerable<ProductResponseDto>> GetProductsAsync()
        {
            try
            {
                var products = await _productRepository.GetProductsAsync();
                return ProductMapper.ToDto(products);
            }
            catch
            {
                throw new InvalidOperationException("An error occurred while fetching the products.");
            }
        }

        public async Task<bool> HasProductAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);
                return product != null;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while checking product existence.", ex);
            }
        }

        public async Task<IEnumerable<ProductResponseDto>> SearchProductsAsync(string productName, string categoryName)
        {
            var products = await _productRepository.SearchProductsAsync(productName, categoryName);
            return ProductMapper.ToDto(products);
        }

        public async Task<ProductResponseDto> UpdateProductAsync(UpdateProductRequestDto dto)
        {
            try
            {

                var existingProduct = await _productRepository.GetProductById(dto.Id);

                if (existingProduct == null)
                    throw new KeyNotFoundException("Product with the specified ID not found.");

                // ProductMapper.ToEntity(existingProduct);
                dto.UpdateEntity(existingProduct);


                var updatedProduct = await _productRepository.UpdateProductRepository(existingProduct);
                return ProductMapper.ToProductResponseDto(updatedProduct);
            }

            catch (KeyNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while updating the product.", ex);
            }
        }

        #endregion
    }
}

using Domain.Mapper.Product;
using Domain.Service.Product;
using Domain.ViewModel.Product;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Product
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        #region properties

        private readonly IProductService _productService;

        #endregion

        #region Constructor

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            try
            {
                var results = await _productService.GetProductsAsync();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("product-id/{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(ProductRequestViewModel viewModel)
        {
            try
            {
                var result = await _productService.CreateProductAsync(ProductMapper.ToDto(viewModel));
                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductRequestViewModel viewModel)
        {
            try
            {
                var result = await _productService.UpdateProductAsync(ProductMapper.ToDto(viewModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchProductsAsync([FromQuery] string? productName, [FromQuery] string? categoryName)
        {
            try
            {
                var results = await _productService.SearchProductsAsync(productName, categoryName);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}

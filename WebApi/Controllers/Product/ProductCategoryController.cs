using Domain.Dto.Product;
using Domain.Service.Product;
using Microsoft.AspNetCore.Mvc;
using Domain.Mapper.Product;
using Domain.ViewModel.Product;

namespace WebApi.Controllers.Product
{
    public class ProductCategoryController : ProductBaseController
    {
        #region Properties

        private readonly IProductCategoryService _productCategoryService;

        #endregion

        #region Constructor

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetProductCategories()
        {
            var categories = await _productCategoryService.GetProductCategoryAsync();
            return Ok(categories.ToViewModel());
        }

        [HttpPost]
        [Route("generate-product-category")]
        public async Task<IActionResult> CreateAsync(ProductCategoryRequestViewModel viewModel)
        {
            await _productCategoryService.CreateProductCategoryAsync(viewModel.ToDto());
            return Ok();
        }

        [HttpPut]
        [Route("update-product-category")]
        public async Task<IActionResult> UpdateProductCategoryAsync(ProductCategoryRequestViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _productCategoryService.UpdateProductCategoryAsync(viewModel.ToDto());

                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("user-id/{id}")]
        public async Task<IActionResult> DeleteProductCategoryAsync(int id)
        {
            try
            {
                await _productCategoryService.DeleteProductCategoryAsync(id);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}

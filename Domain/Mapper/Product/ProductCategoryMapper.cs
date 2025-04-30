using Domain.Dto.Product;
using Domain.Entity.Product;
using Domain.ViewModel.Product;

namespace Domain.Mapper.Product
{
    public static class ProductCategoryMapper
    {
        #region ToViewModel

        public static ProductCategoryRequestViewModel ToViewModel(this ProductCategoryRequestDto dto)
        {
            return new ProductCategoryRequestViewModel
            {
                Name = dto.Name,
                CreateDateTime = dto.CreateDate
            };
        }

        public static List<ProductCategoryRequestViewModel> ToViewModel(this List<ProductCategoryRequestDto> dtos)
        {
            return dtos.Select(item => item.ToViewModel()).ToList();
        }

        #endregion

        #region ToDto

        public static ProductCategoryRequestDto ToDto(this ProductCategoryRequestViewModel viewModel)
        {
            return new ProductCategoryRequestDto
            {
                Name = viewModel.Name,
                CreateDate = viewModel.CreateDateTime
            };
        }

        #endregion

        #region ToEntity

        public static ProductCategory ToEntity(this ProductCategoryRequestDto dto)
        {
            return new ProductCategory
            {
                Name = dto.Name,
                CreatedDate = dto.CreateDate
            };
        }

        #endregion
    }
}

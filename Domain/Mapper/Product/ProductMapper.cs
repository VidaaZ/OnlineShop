using Domain.Dto.Product;
using Domain.Entity.Product;
using Domain.ViewModel.Product;


namespace Domain.Mapper.Product
{
    public static class ProductMapper
    {
        #region ToDto
        public static ProductRequestDto ToDto(this ProductRequestViewModel viewModel)
        {
            return new ProductRequestDto
            {
                CategoryId = viewModel.CategoryId,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                StockQuantity = viewModel.StockQuantity,
                CreatedDate = viewModel.CreatedDate,
                UpdatedDate = viewModel.UpdatedDate
            };
        }
        public static UpdateProductRequestDto ToDto(this UpdateProductRequestViewModel viewModel)
        {
            return new UpdateProductRequestDto
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                StockQuantity = viewModel.StockQuantity,
                CreatedDate = viewModel.CreatedDate,
                UpdatedDate = viewModel.UpdatedDate,
                CategoryId = viewModel.CategoryId
            };
        }
        public static UpdateProductRequestDto ToDto(this Domain.Entity.Product.Product entity)
        {
            return new UpdateProductRequestDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price.ToString(),
                StockQuantity = entity.StockQuantity,
                CreatedDate = entity.CreatedDate.ToString(),
                UpdatedDate = entity.UpdatedDate.ToString(),
                CategoryId = entity.CategoryId
            };
        }
        public static ProductResponseDto ToProductResponseDto(this Entity.Product.Product entity)
        {
            return new ProductResponseDto
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price.ToString(),
                StockQuantity = entity.StockQuantity,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate,
                CategoryId = entity.CategoryId
            };
        }
        public static IEnumerable<ProductResponseDto> ToDto(this IEnumerable<Entity.Product.Product> entities)
        {
            return entities.Select(item => item.ToProductResponseDto());
        }

        #endregion

        #region ToEntity

        public static Entity.Product.Product ToEntity(this ProductRequestDto dto)
        {
            return new Entity.Product.Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = Convert.ToInt64(dto.Price),
                StockQuantity = dto.StockQuantity ?? 0,
                CreatedDate = DateTime.TryParse(dto.CreatedDate, out DateTime createdDate) ? createdDate : DateTime.MinValue,
                UpdatedDate = DateTime.TryParse(dto.UpdatedDate, out DateTime updateDate) ? updateDate : DateTime.MinValue,
                CategoryId = dto.CategoryId,

                 BrandId = 1,        
                IsActive = true
            };
        }

        public static ProductImage ToEntity(this ProductImageDto dto, MemoryStream ms)
        {
            return new ProductImage
            {
                ImageData = ms.ToArray(),
                ProductId = dto.ProductId,
                ContentType = dto.ContentType
            };
        }
       
        #endregion
    }
}

using Microsoft.AspNetCore.Http;

namespace Domain.Dto.Product
{
    public class ProductImageDto
    {
        public List<IFormFile> ImageDatas { get; set; }
        public string ContentType { get; set; }
        public int ProductId { get; set; }
    }
}

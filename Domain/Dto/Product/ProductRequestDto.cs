using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.Product
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int? StockQuantity { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public int CategoryId { get; set; }
    }
}

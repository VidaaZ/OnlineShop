using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entity.Company;

namespace Domain.Entity.Product
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsActive { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public List<ProductImage> ProductImages { get; set; }

    }

}

using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Product
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public List<Product> Products { get; set; }

    }
}

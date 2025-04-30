using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Company
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Logo { get; set; }

        public string Website { get; set; }

        public string CountryOfOrigin { get; set; }

        public int EstablishedYear { get; set; }

        public bool IsActive { get; set; }

        public List<Product.Product> Products { get; set; }

    }

}

using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModel.Product
{
    public class ProductCategoryRequestViewModel
    {
        [Required(ErrorMessage = "Name must be filled")]
        public string Name { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}

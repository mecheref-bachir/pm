using System.ComponentModel.DataAnnotations;

namespace project.Models.ShoppingCartModels.Dto
{
    public class ProductModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ProductCategory { get; set; }

        public string Vendor { get; set; }
    }
}

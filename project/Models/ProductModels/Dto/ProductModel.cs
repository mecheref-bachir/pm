using System.ComponentModel.DataAnnotations;

namespace project.Models.ProductModels.Dto
{
    public class ProductModel
    {
        public int PrdoductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ProductCategory { get; set; }

        public string Vendor { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string ImageUrl { get; set; }

    }
}

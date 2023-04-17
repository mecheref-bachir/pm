using System.ComponentModel.DataAnnotations;

namespace project.Models.ProductModels.Domain
{
    public class Product 
    {
        [Key]
        public int PrdoductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ProductCategory { get; set; }
        [Required]
        public string vendor { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public bool isAproved { get; set; }
    }
}

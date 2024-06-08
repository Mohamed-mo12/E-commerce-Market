using System.ComponentModel.DataAnnotations;

namespace Market.DTO.Products
{
    public class CreateProdcutDataDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 characters")]
        public string Name { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public double Price { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Description length can't be more than 500 characters")]
        public string Description { get; set; }
        [Required]

        public IFormFile Image { get; set; }
        [Required]
        public int Category_id { get; set; }
    }
}

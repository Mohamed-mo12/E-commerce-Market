using System.ComponentModel.DataAnnotations;

namespace Market.DTO.Products
{
    public class UpdateProductDataDTO
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
    }
}

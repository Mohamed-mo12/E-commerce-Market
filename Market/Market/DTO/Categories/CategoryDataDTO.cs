using System.ComponentModel.DataAnnotations;

namespace Market.DTO.Categories
{
    public class CategoryDataDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}

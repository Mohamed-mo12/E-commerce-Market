using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string Image { get; set; }
        public int Category_ID { get; set; }
        [ForeignKey("Category_ID")]
        public Category Category { get; set; }
    }
}

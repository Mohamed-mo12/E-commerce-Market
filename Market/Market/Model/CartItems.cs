using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Model
{
    public class CartItems
    {
        public int ID { get; set; }
        public int ShoppingCart_id { get; set; }
        [ForeignKey("ShoppingCart_id")]
        public ShoppingCart Cart { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}

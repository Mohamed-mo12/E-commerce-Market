using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Model
{
    public class ProductOrder
    {
        public int Product_ID { get; set; }
        [ForeignKey("Product_ID")]
        public Product Product { get; set; }
        public int Oredr_ID { get; set; }
        [ForeignKey("Oredr_ID")]
        public Order Order { get; set; }
    }
}

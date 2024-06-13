using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Model
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public string User_ID { get; set; }
        [ForeignKey("User_ID")]
        public ApplicationUser User { get; set; }
        public ICollection<CartItems> CartItems { get; set; }
    }
}

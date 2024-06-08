using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Model
{
    public class Order
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Order_Time { get; set; }
        public double Total_Amount { get; set; }

        public string User_ID { get; set; }
        [ForeignKey("User_ID")]
        public ApplicationUser User { get; set; }
        public Payment Payment { get; set; }
    }
}

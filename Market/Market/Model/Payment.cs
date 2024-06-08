using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Model
{
    public class Payment
    {
        public int ID { get; set; }
        public PaymentMethodEnum Payment_Method { get; set; }
        public double Amount { get; set; }
        public int Order_Id { get; set; }
        [ForeignKey("Order_Id")]
        public Order Order { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Model
{
    public class FeedbackAndRating
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public string User_ID { get; set; }
        [ForeignKey("User_ID")]
        public ApplicationUser User { get; set; }
    }
}

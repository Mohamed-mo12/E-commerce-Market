using Microsoft.AspNetCore.Identity;

namespace Market.Model
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
        public ICollection<FeedbackAndRating> FeedBacks { get; set; }
    }
}

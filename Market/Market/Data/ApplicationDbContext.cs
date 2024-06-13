using Market.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Market.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Payment>().Property(p => p.Payment_Method).HasConversion<string>();
            builder.Entity<ProductOrder>().HasKey(p => new { p.Oredr_ID, p.Product_ID });
            base.OnModelCreating(builder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<FeedbackAndRating> FeedBacks { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItems> cartItems { get; set; }
    }
}

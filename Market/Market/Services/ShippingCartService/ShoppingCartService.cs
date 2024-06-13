using Market.Data;
using Market.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Market.Services.ShippingCartService
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext context; 
        public ShoppingCartService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<CartItems> AddItemToCart(string UserID, int ProductId, int Quantity)
        {
            var shopping = await context.ShoppingCarts.Include(x => x.CartItems)
                 .FirstOrDefaultAsync(x=>x.User_ID==UserID);
            if (shopping==null)
            {
                var shoppingcart = new ShoppingCart { User_ID = UserID };
                await context.ShoppingCarts.AddAsync(shoppingcart);
                await context.SaveChangesAsync(); 
            }
            var cartitem = new CartItems
            {
                ProductId = ProductId,
                Quantity = Quantity,
                ShoppingCart_id = shopping.ID
            };

            await context.cartItems.AddAsync(cartitem);
            await context.SaveChangesAsync();
            return cartitem; 



        }
    }
}

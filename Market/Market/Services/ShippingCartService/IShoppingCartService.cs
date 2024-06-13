using Market.Model;

namespace Market.Services.ShippingCartService
{
    public interface IShoppingCartService
    {
        Task<CartItems> AddItemToCart(string UserID,int ProductId,int Quantity); 
    }
}

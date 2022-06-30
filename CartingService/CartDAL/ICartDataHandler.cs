using Business.Core.Cart;

namespace CartingService.CartDAL
{
    public interface ICartDataHandler
    {
        Task<List<Cart>> GetAllCartsWithItems();
        Task AddCartWithItems(Cart c);

        Task AddItemToCart(CartItem item, string cartId);
        Task<Cart> GetCartById(string id);

        Task RemoveItemFromCart(string itemId, string cartId);
    }
}

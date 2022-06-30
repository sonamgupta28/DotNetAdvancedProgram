using Business.Core.Cart;

namespace CartingService.CartBLL
{
    public interface ICartBL
    {
        Task<List<Cart>> GetAllCartsWithItems();

        void AddCartWithItems(Cart cart);

        void AddItemToCart(string cartId, CartItem cartItem);
        void RemoveItemFromCart(string cartId, string itemId);

        Task<Cart> GetCartById(string id);
    }
}

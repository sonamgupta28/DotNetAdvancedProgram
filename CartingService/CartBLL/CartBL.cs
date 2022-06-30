using Business.Core.Cart;
using CartingService.CartDAL;

namespace CartingService.CartBLL
{
    public class CartBL :ICartBL
    {
        private readonly ILogger<CartBL> _logger;
        private readonly ICartDataHandler _dl;

        public CartBL(ILogger<CartBL> logger, ICartDataHandler dl)
        {
            _logger = logger;
            _dl = dl;
        }
        public async Task<List<Cart>> GetAllCartsWithItems()
        {
            return await _dl.GetAllCartsWithItems();
        }

        public async Task<Cart> GetCartById(string id)
        {
            return await _dl.GetCartById(id);
        }

        public async void AddCartWithItems(Cart cart)
        {
            await _dl.AddCartWithItems(cart);
        }
        public async void AddItemToCart(string cartId, CartItem item)
        {
            await _dl.AddItemToCart(item, cartId);
        }

        public async void RemoveItemFromCart(string cartId, string itemId)
        {
            await _dl.RemoveItemFromCart(itemId, cartId);
        }
    }
}

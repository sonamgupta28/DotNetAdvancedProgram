using Business.Core.Cart;
using CartingService.CartBLL;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartingController : ControllerBase
    {     

        private readonly ILogger<CartingController> _logger;
        private readonly ICartBL _bl;

        public CartingController(ILogger<CartingController> logger, ICartBL bl)
        {
            _bl = bl;
        }

        [HttpGet("GetCarts")]
        public async Task<List<Cart>> Get()
        {
            return await _bl.GetAllCartsWithItems();
        }

        [HttpPost("AddCartWithItems")]
        public void AddCartWithItems(Cart cart)
        {
            _bl.AddCartWithItems(cart);
        }

        [HttpPost("AddItemToCart/{cartId}")]
        public void AddItemToCart(string cartId, CartItem item)
        {
            _bl.AddItemToCart(cartId, item);
        }

        [HttpPost("RemoveItemFromCart/{cartId}/{itemId}")]
        public void RemoveItemFromCart(string cartId, string itemId)
        {
            _bl.RemoveItemFromCart(cartId, itemId);
        }
    }
}
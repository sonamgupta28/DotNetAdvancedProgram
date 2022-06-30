using Business.Core.Cart;
using CartingService.CartBLL;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]

    public class CartingController : ControllerBase
    {     

        private readonly ILogger<CartingController> _logger;
        private readonly ICartBL _bl;

        public CartingController(ILogger<CartingController> logger, ICartBL bl)
        {
            _bl = bl;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("getcartinfo/{cartid}")]
        public async Task<Cart> GetWithId(string cartid)
        {
            return await _bl.GetCartById(cartid);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("getcartinfo")]
        public async Task<List<Cart>> Get()
        {
            return await _bl.GetAllCartsWithItems();
        }

        [HttpPost("addcartwithitems")]
        public void AddCartWithItems(Cart cart)
        {
            _bl.AddCartWithItems(cart);
        }

        [MapToApiVersion("1.0")]
        [MapToApiVersion("2.0")]
        [HttpPost("additemtocart/{cartId}")]
        public void AddItemToCart(string cartId, CartItem item)
        {
            _bl.AddItemToCart(cartId, item);
        }

        [MapToApiVersion("1.0")]
        [MapToApiVersion("2.0")]
        [HttpPost("deleteitemfromcart/{cartId}/{itemId}")]
        public void RemoveItemFromCart(string cartId, string itemId)
        {
            _bl.RemoveItemFromCart(cartId, itemId);
        }
    }
}
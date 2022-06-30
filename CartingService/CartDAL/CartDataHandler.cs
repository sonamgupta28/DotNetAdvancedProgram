using Business.Core.Cart;
using Business.Core.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CartingService.CartDAL
{
    public class CartDataHandler: ICartDataHandler
    {

        private readonly IMongoCollection<Cart> _carts;
        private readonly IMongoClient _mongoCient;

        public CartDataHandler(IOptions<DatabaseSettings> options,IMongoClient mongoCient)
        {
            _mongoCient = mongoCient;

            _carts = _mongoCient
                .GetDatabase(options.Value.DatabaseName)
                .GetCollection<Cart>(options.Value.CollectionName);
        }

        public async Task<List<Cart>> GetAllCartsWithItems() =>
            await _carts.Find(_ => true).ToListAsync();

        public async Task<Cart> GetCartById(string id)
        {
            return await _carts.Find(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task AddCartWithItems(Cart c)
        {
            await _carts.InsertOneAsync(c);
        }

        public async Task AddItemToCart(CartItem item, string cartId)
        {
            var cart = await _carts.Find(s => s.Id == cartId).FirstOrDefaultAsync();
            cart.Items.Add(item);
            await _carts.ReplaceOneAsync(s => s.Id == cartId, cart);
        }

        public async Task RemoveItemFromCart(string itemId, string cartId)
        {
            var cart = await _carts.Find(s => s.Id == cartId).FirstOrDefaultAsync();
            var item = cart.Items.Find(x => x._id == itemId);
            cart.Items.Remove(item);
            await _carts.ReplaceOneAsync(s => s.Id == cartId, cart);
        }
    }
}

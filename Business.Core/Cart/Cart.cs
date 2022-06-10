using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Cart
{
    public class Cart
    {

        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("items")]
        public List<CartItem> Items { get; set; }

    }

}

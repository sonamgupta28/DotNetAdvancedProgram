using Business.Core.Catalog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAccessLayer
{
    public class ItemRepository : IDataRepository<Item>
    {
        readonly CatalogContext _context;
        public ItemRepository(CatalogContext context)
        {
            _context = context;
        }
        Item IDataRepository<Item>.Add(Item entity)
        {
            _context.Items.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        Item IDataRepository<Item>.Delete(int id)
        {
            var item = _context.Items
                    .FirstOrDefault(e => e.ItemId == id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
            return item;

        }

        Item IDataRepository<Item>.Get(long id)
        {
            return _context.Items
                  .FirstOrDefault(predicate: e => e.ItemId == id);
        }

        IEnumerable<Item> IDataRepository<Item>.GetAll()
        {
            return _context.Items.Include(x => x.Category).ToList();
        }

        Item IDataRepository<Item>.Update(int id, Item item)
        {
            var oldItem = _context.Items.FirstOrDefault(x => x.ItemId == id);
            if (oldItem != null)
            {
                oldItem.Name = item.Name;
                oldItem.Image = item.Image;
                oldItem.Description = item.Description;
                oldItem.Category = item.Category;
                oldItem.Price = item.Price;
                oldItem.Amount = item.Amount;
                _context.Items.Update(oldItem);
                _context.SaveChanges();
                return item;
            }
            return null;

        }
    }
}

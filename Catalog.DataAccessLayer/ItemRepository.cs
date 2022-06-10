using Business.Core.Catalog;
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
        void IDataRepository<Item>.Add(Item entity)
        {
            _context.Items.Add(entity);
            _context.SaveChanges();
        }

        void IDataRepository<Item>.Delete(Item entity)
        {
            _context.Items.Remove(entity);
            _context.SaveChanges();
        }

        Item IDataRepository<Item>.Get(long id)
        {
            return _context.Items
                  .FirstOrDefault(predicate: e => e.ItemId == id);
        }

        IEnumerable<Item> IDataRepository<Item>.GetAll()
        {
            return _context.Items.ToList();
        }

        void IDataRepository<Item>.Update(Item dbEntity, Item entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Image = entity.Image;
            dbEntity.Description = entity.Description;
            dbEntity.Category = entity.Category;
            dbEntity.Price = entity.Price;
            dbEntity.Amount = entity.Amount;

            _context.SaveChanges();
        }
    }
}

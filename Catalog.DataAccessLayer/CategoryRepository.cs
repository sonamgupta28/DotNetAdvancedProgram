using Business.Core.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAccessLayer
{
    public class CategoryRepository : IDataRepository<Category>
    {
        readonly CatalogContext _context;
        public CategoryRepository(CatalogContext context)
        {
            _context = context;
        }
        void IDataRepository<Category>.Add(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
        }

        void IDataRepository<Category>.Delete(Category entity)
        {
            _context.Categories.Remove(entity);
            _context.SaveChanges();
        }

        Category IDataRepository<Category>.Get(long id)
        {
            //    return _context.Categories
            //          .FirstOrDefault(e => e.CategoryId == id);
            //}

            throw new NotImplementedException();
        }

        IEnumerable<Category> IDataRepository<Category>.GetAll()
        {
            return _context.Categories.ToList();
        }

        void IDataRepository<Category>.Update(Category dbEntity, Category entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Image = entity.Image;
            dbEntity.ParentCategory = entity.ParentCategory;

            _context.SaveChanges();
        }
   
    }
}

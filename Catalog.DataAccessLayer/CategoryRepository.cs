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
        Category IDataRepository<Category>.Add(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        Category IDataRepository<Category>.Delete(int id)
        {
            var category = _context.Categories
                      .FirstOrDefault(e => e.CategoryId == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return category;

        }

        Category IDataRepository<Category>.Get(long id)
        {

            throw new NotImplementedException();
        }

        IEnumerable<Category> IDataRepository<Category>.GetAll()
        {
            return _context.Categories.ToList();
        }

        Category IDataRepository<Category>.Update(int id, Category category)
        {
            var oldCategory = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (oldCategory != null)
            {
                oldCategory.Name = category.Name;
                oldCategory.Image = category.Image;
                oldCategory.ParentCategory = category.ParentCategory;
                _context.Categories.Update(oldCategory);
                _context.SaveChanges();
                return category;
            }
            return null;


        }

    }
}

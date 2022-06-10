using Business.Core.Catalog;
using Catalog.DataAccessLayer;

namespace Catalog.BusinessLogicLayer
{
    public class CategoriesManager : IBusinessLayer<Category>
    {
        private readonly IDataRepository<Category> _categoriesRepository;

        public CategoriesManager(IDataRepository<Category> categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        public void Add(Category entity)
        {
            _categoriesRepository.Add(entity);
        }

        public void Delete(Category entity)
        {
            _categoriesRepository.Delete(entity);
        }

        public Category Get(long id)
        {
            Category item = _categoriesRepository.Get(id);
            if (item == null)
            {
                return null;
            }
            return item;
        }

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> items = _categoriesRepository.GetAll();
            return items;
        }

        public void Update(Category dbEntity, Category entity)
        {
            _categoriesRepository.Update(dbEntity, entity);
        }
    
    }
}

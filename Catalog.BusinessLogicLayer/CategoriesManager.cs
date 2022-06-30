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
        public Category Add(Category entity)
        {
            return _categoriesRepository.Add(entity);
        }

        public Category Delete(int entity)
        {
            return _categoriesRepository.Delete(entity);
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

        public List<Category> Get(int id, int pageNumber)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> items = _categoriesRepository.GetAll();
            return items;
        }

        public Category Update(int id, Category entity)
        {
            return _categoriesRepository.Update(id, entity);
        }
    
    }
}

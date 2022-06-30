using Business.Core.Catalog;
using Catalog.DataAccessLayer;

namespace Catalog.BusinessLogicLayer
{
    public class ItemsManager : IBusinessLayer<Item>
    {
        private readonly IDataRepository<Item> _itemRepository;
        private const int RecordsPerPage = 5;

        public ItemsManager(IDataRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public Item Add(Item entity)
        {
            return _itemRepository.Add(entity);
        }

        public Item Delete(int id)
        {
            return _itemRepository.Delete(id);
        }

        public Item Get(long id)
        {
            Item item = _itemRepository.Get(id);
            if (item == null)
            {
                return null;
            }
            return item;
        }

        public IEnumerable<Item> GetAll()
        {
            IEnumerable<Item> items = _itemRepository.GetAll();
            return items;
        }

        public List<Item> Get(int categoryId, int pageNumber)
        {
            var items = _itemRepository.GetAll();

            var filteredItems = items.Where(p => p.Category?.CategoryId == categoryId)
                                                .Skip((pageNumber - 1) * RecordsPerPage)
                                                .Take(RecordsPerPage).ToList();

            return (filteredItems);
        }


        public Item Update(int id, Item entity)
        {
            return _itemRepository.Update(id, entity);
        }
    }
}
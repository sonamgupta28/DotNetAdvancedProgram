using Business.Core.Catalog;
using Catalog.DataAccessLayer;

namespace Catalog.BusinessLogicLayer
{
    public class ItemsManager : IBusinessLayer<Item>
    {
        private readonly IDataRepository<Item> _itemRepository;

        public ItemsManager(IDataRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public void Add(Item entity)
        {
            _itemRepository.Add(entity);
        }

        public void Delete(Item entity)
        {
            _itemRepository.Delete(entity);
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

        public void Update(Item dbEntity, Item entity)
        {
           _itemRepository.Update(dbEntity, entity);
        }
    }
}
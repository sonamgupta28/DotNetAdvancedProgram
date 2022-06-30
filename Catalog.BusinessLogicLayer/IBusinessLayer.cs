namespace Catalog.BusinessLogicLayer
{
    public interface IBusinessLayer<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        List<TEntity> Get(int id, int pageNumber);
        TEntity Get(long id);
        TEntity Add(TEntity entity);
        TEntity Update(int id, TEntity entity);
        TEntity Delete(int id);

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAccessLayer
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TEntity Add(TEntity entity);
        TEntity Update(int id, TEntity entity);
        TEntity Delete(int id);


    }
}

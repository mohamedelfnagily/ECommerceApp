using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Repository.Generic
{
    public interface IBaseRepository<TEntity>where TEntity : class
    {
        //This interface is responsible for the signature of the methods used with all controllers
        //It is classified into 4 main parts:
        //1-Getting methods, 2-Adding Methods, 3-Deleting Methods, 4-Updating Methods
        //Getting Section:
        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        //Adding Section
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        //Deleting Section
        TEntity Delete(Guid id);
        TEntity Delete(TEntity entity);
        IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> DeleteRange(IEnumerable<Guid> Ids);
        //Updating Section
        TEntity Update(TEntity entity);

    }
}

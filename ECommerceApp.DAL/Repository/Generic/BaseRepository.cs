using ECommerceApp.DAL.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Repository.Generic
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        //This class have all the implementation of the methods in the IBaseRepository
        //Since we depend on EntityFrameworkCore here we are injecting the applicationDbContext to have access on the tables in db
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //Get Section:
        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();

        }
        //Add Section:

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            return entities;
        }
        //Delete Section:
        public TEntity Delete(Guid id)
        {
            var myEntity = GetById(id);
            _context.Set<TEntity>().Remove(myEntity);
            return myEntity;
        }

        public TEntity Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return entity;
        }

        public IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            return entities;
        }

        public IEnumerable<TEntity> DeleteRange(IEnumerable<Guid> Ids)
        {
            List<TEntity> myEntites = new List<TEntity>();
            foreach(Guid id in Ids)
            {
                var myEntity = GetById(id) as TEntity;
                if(myEntity!=null)
                {
                    myEntites.Add(myEntity);
                }
            }
            _context.Set<TEntity>().RemoveRange(myEntites);
            return myEntites;
        }
        //Update Section:
        public TEntity Update(TEntity entity)
        {
            //This method will be empty as EntityFrameworkCore track all changes occurs on the entity
            //But it is implemented regarding any Change in the future
            return entity;
        }
    }
}

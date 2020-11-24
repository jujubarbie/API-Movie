using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesRental.DAL.Services
{
    public interface IService<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        //TKey Insert(TEntity entity);
        //TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();
        //bool Update(TEntity entity);
        //bool Delete(TKey key);


        // todo : faire les flux update, get, delete, insert
    }
}

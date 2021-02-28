using ForumDemo.Models.EF.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ForumDemo.Models.EF.Repositories
{
    public interface IRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> Get(TKey id);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAll(Func<TEntity, bool> predicate);
        Task Update(TEntity entity);
        Task<TEntity> Create(TEntity entity);
        Task Delete(TKey id);
    }
}
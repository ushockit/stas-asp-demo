using ForumDemo.Models.EF.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ForumDemo.Models.EF.Repositories
{
    public abstract class BaseRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : BaseEntity<TKey>
    {
        protected ApplicationDbContext db;
        protected DbSet<TEntity> Table => db.Set<TEntity>();

        static BaseRepository()
        {
            Database.SetInitializer(new ForumInitializer());
        }
        public BaseRepository()
        {
            db = new ApplicationDbContext();
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Added;
            await db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task Delete(TKey id)
        {
            var entity = await Get(id);
            db.Entry(entity).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public abstract Task<TEntity> Get(TKey id);

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await Table.ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll(Func<TEntity, bool> predicate)
        {
            return await Task.FromResult(Table.Where(predicate).ToList());
        }

        public abstract Task Update(TEntity entity);
    }
}
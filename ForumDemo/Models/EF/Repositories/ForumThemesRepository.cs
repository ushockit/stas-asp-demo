using ForumDemo.Models.EF.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace ForumDemo.Models.EF.Repositories
{
    public class ForumThemesRepository : BaseRepository<int, ForumTheme>
    {
        public ForumThemesRepository()
        {
        }

        public override async Task<ForumTheme> Get(int id)
        {
            return await Table.Include(entity => entity.Messages)
                .FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public override async Task<List<ForumTheme>> GetAll()
        {
            return await Table.Include(entity => entity.Messages)
                .Include(entity => entity.Owner)
                .ToListAsync();
        }

        public override async Task<List<ForumTheme>> GetAll(Func<ForumTheme, bool> predicate)
        {
            return await Task.FromResult(Table.Include(entity => entity.Messages)
                .Include(entity => entity.Owner)
                .Where(predicate).ToList());
        }

        public override async Task Update(ForumTheme entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.IsPublished = entity.IsPublished;
            srchEntity.Messages = entity.Messages;
            srchEntity.Title = entity.Title;
            srchEntity.Description = entity.Description;
            db.Entry(srchEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<ForumTheme> GetUserTheme(int themeId, string userId)
        {
            return await Table.FirstOrDefaultAsync(entity => entity.Id == themeId && entity.OwnerId.Equals(userId));
        }
    }
}
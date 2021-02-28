using ForumDemo.Models.EF.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace ForumDemo.Models.EF.Repositories
{
    public class ThemeMessagesRepository : BaseRepository<int, ThemeMessage>
    {
        public ThemeMessagesRepository()
        {
        }

        public override async Task<ThemeMessage> Get(int id)
        {
            return await Table.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public override async Task Update(ThemeMessage entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Text = entity.Text;
            db.Entry(srchEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<ThemeMessage> GetUserMessage(int id, string userId)
        {
            return await Table.FirstOrDefaultAsync(entity => entity.Id == id && entity.PublisherId.Equals(userId));
        }
    }
}
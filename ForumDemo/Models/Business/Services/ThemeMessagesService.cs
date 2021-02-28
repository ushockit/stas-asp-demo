using ForumDemo.Models.Automapper;
using ForumDemo.Models.Business.Exceptions;
using ForumDemo.Models.DTO;
using ForumDemo.Models.EF.Entites;
using ForumDemo.Models.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ForumDemo.Models.Business.Services
{
    public class ThemeMessagesService
    {
        ThemeMessagesRepository themeMessagesRepository;
        ObjectAutoMapper mapper;
        public ThemeMessagesService()
        {
            themeMessagesRepository = new ThemeMessagesRepository();
            mapper = new ObjectAutoMapper();
        }

        public async Task<ThemeMessageDto> GetMessageById(int id, string userId)
        {
            var msg = await themeMessagesRepository.GetUserMessage(id, userId);
            if (msg is null)
            {
                throw new NotUserMessageException();
            }

            var entity = await themeMessagesRepository.Get(id);
            return mapper.Mapper.Map<ThemeMessageDto>(entity);
        }

        public async Task ModifyMessage(ThemeMessageDto msg)
        {
            await themeMessagesRepository.Update(mapper.Mapper.Map<ThemeMessage>(msg));
        }
    }
}
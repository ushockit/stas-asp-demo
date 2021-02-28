using AutoMapper;
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
    public class ForumThemesService
    {
        ForumThemesRepository forumThemesRepository;
        ThemeMessagesRepository themeMessagesRepository;
        ObjectAutoMapper mapper;
        public ForumThemesService()
        {
            forumThemesRepository = new ForumThemesRepository();
            themeMessagesRepository = new ThemeMessagesRepository();
            mapper = new ObjectAutoMapper();
        }

        public async Task<List<ForumThemeDto>> GetAllThemes()
        {
            var themes = await forumThemesRepository.GetAll();
            return mapper.Mapper.Map<List<ForumThemeDto>>(themes);
        }

        public async Task<ForumThemeDto> GetTheme(int id)
        {
            var theme = await forumThemesRepository.Get(id);
            return mapper.Mapper.Map<ForumThemeDto>(theme);
        }

        public async Task<List<ForumThemeDto>> GetUserThemes(string userId)
        {
            var themes = await forumThemesRepository.GetAll(entity => entity.Owner.Id.Equals(userId));
            return mapper.Mapper.Map<List<ForumThemeDto>>(themes);
        }

        public async Task CreateTheme(ForumThemeDto theme, string ownerId)
        {
            //Theme owner
            theme.OwnerId = ownerId;
            var themeEntity = mapper.Mapper.Map<ForumTheme>(theme);
            await forumThemesRepository.Create(themeEntity);
        }

        public async Task RemoveTheme(int id, string userId)
        {
            //Check user theme
            var theme = await forumThemesRepository.GetUserTheme(id, userId);

            //Remove other theme
            if (theme is null)
            {
                throw new NotUserThemeException();
            }

            await forumThemesRepository.Delete(id);
        }

        public async Task AddMessage(ThemeMessageDto msg, int themeId, string userId)
        {
            msg.PublisherId = userId;
            await themeMessagesRepository.Create(mapper.Mapper.Map<ThemeMessage>(msg));

        }
    }
}
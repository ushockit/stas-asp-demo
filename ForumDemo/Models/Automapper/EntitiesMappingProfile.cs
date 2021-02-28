using AutoMapper;
using ForumDemo.Models.DTO;
using ForumDemo.Models.EF.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDemo.Models.Automapper
{
    public class EntitiesMappingProfile : Profile
    {
        public EntitiesMappingProfile()
        {
            CreateMap<ThemeMessage, ThemeMessageDto>();
            CreateMap<ThemeMessageDto, ThemeMessage>();

            CreateMap<ForumTheme, ForumThemeDto>();
            CreateMap<ForumThemeDto, ForumTheme>();
        }
    }
}
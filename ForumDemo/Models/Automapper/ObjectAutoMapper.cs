using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDemo.Models.Automapper
{
    public class ObjectAutoMapper
    {
        public IMapper Mapper { get; }
        public ObjectAutoMapper()
        {
            var mapCnfg = new MapperConfiguration(cnfg =>
            {
                cnfg.AddProfile(new EntitiesMappingProfile());
            });
            Mapper = mapCnfg.CreateMapper();
        }
    }
}
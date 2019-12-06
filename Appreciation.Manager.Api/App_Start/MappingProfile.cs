using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Appreciation.Manager.Api.App_Start
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper(Type source, Type target)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMappings(source, target));

            return config;
        }

        public static void CreateMappings(this IMapperConfigurationExpression cfg, Type source, Type target)
        {
            foreach (Type sc in Assembly.GetAssembly(source).GetTypes().Where(x => x.IsClass && x.IsSubclassOf(typeof(BaseEntity))))
            {
                var name = sc.Name;
                foreach (Type tg in Assembly.GetAssembly(target).GetTypes().Where(x => x.IsClass && x.IsSubclassOf(typeof(Request)) && x.Name.Contains(name)))
                {
                    // registry source
                    cfg.CreateMap(sc, tg);
                    // registry target
                    cfg.CreateMap(tg, sc);
                }
            }
        }
    }
}
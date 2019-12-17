using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;

namespace Appreciation.Manager.Services.Contracts.Mappers
{
    public static class SchoolYearMapper
    {
        public static void ProjectTo(this UpdateSchoolYearRequest request, SchoolYear entity)
        {
            entity.Name = request.Name;
            entity.IsClosed = request.IsClosed;
        }

        public static SchoolYear ProjectTo(this AddSchoolYearRequest request, IMapper mapper)
        {
            SchoolYear item = mapper.Map<SchoolYear>(request);
            item.DateCreated = DateTime.Now;
            return item;
        }
    }
}

using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;

namespace Appreciation.Manager.Services.Contracts.Mappers
{
    public static class ClassroomMapper
    {
        public static void ProjectTo(this UpdateClassroomRequest request, Classroom classroom)
        {
            classroom.ClassNumber = request.ClassNumber;
        }

        public static Classroom ProjectTo(this AddClassroomRequest request, IMapper mapper)
        {
            Classroom cr = mapper.Map<Classroom>(request);
            cr.DateCreated = DateTime.Now;
            return cr;
        }
    }
}

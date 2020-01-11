using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;

namespace Appreciation.Manager.Services.Contracts.Mappers
{
    public static class ExamMapper
    {
        public static void ProjectTo(this ExamRequest request, Exam exam)
        {
            exam.Name = request.Name;
        }

        public static Exam ProjectTo(this ExamRequest request, IMapper mapper)
        {
            Exam ex = mapper.Map<Exam>(request);
            ex.DateCreated = DateTime.Now;
            return ex;
        }
    }
}

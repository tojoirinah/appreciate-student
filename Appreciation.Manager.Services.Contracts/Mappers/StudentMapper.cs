using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;

namespace Appreciation.Manager.Services.Mappers
{
    public static class StudentMapper
    {
        public static void ProjectTo(this UpdateInformationStudentRequest request, Student student)
        {
            student.Age = request.Age;
            student.Civility = request.Civility;
            student.ClassRoomId = request.ClassRoomId;
            student.SchoolYearId = request.SchoolYearId;
            request.User.ProjectTo(student.User);
        }

        public static Student ProjectTo(this AddStudentRequest request, IMapper mapper)
        {
            Student std = mapper.Map<Student>(request);
            std.DateCreated = DateTime.Now;
            return std;
        }
    }
}

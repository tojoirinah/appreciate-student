using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Linq;
using System.Collections.Generic;
using Appreciation.Manager.Infrastructure.Enumerations;

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

        public static Student ProjectTo(this AddStudentRequest request, IMapper mapper, RoleEnum roleEnum)
        {
            Student std = mapper.Map<Student>(request);
            std.DateCreated = DateTime.Now;
            std.User = request.User.ProjectTo(mapper, roleEnum);
            return std;
        }

        public static List<Student> ProjectTo(this List<AddStudentRequest> request, IMapper mapper, RoleEnum roleEnum)
        {
            return request.Select(x => x.ProjectTo(mapper, roleEnum)).ToList();
        }
    }
}

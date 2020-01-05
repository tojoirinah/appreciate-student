using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class VStudentService : Service<VStudent>, IVStudentService
    {
        public VStudentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override Task AddAsync(object request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VStudent>> SearchStudent(StudentSearchRequest request)
        {
            var schoolYearIdParameter = new SqlParameter
            {
                ParameterName = "schoolYearId",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.BigInt,
                Value = request.SchoolYearId
            };

            var classroomIdParameter = new SqlParameter
            {
                ParameterName = "classroomId",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.BigInt,
                Value = request.ClassroomId
            };



            return await _repository.ExecWithStoreProcedure("dbo.sp_SearchStudent @schoolYearId, @classroomId", schoolYearIdParameter, classroomIdParameter);
        }

        public override Task UpdateAsync(object request)
        {
            throw new NotImplementedException();
        }
    }
}

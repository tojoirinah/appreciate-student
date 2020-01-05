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
    public class VNoteEvaluateService : Service<VNoteEvaluate>, IVNoteEvaluateService
    {
        public VNoteEvaluateService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override Task AddAsync(object request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VNoteEvaluate>> SearchNoteEvaluate(NoteEvaluateSearchRequest request)
        {
            var noteCriteriaIdParameter = new SqlParameter
            {
                ParameterName = "noteCriteriaId",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.BigInt,
                Value = request.NoteCriteriaId
            };


            return await _repository.ExecWithStoreProcedure("dbo.sp_SearchNoteEvaluate @noteCriteriaId", noteCriteriaIdParameter);
        }

        public override Task UpdateAsync(object request)
        {
            throw new NotImplementedException();
        }
    }
}

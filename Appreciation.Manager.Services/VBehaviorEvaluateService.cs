using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class VBehaviorEvaluateService : Service<VBehaviorEvaluate>, IVBehaviorEvaluateService
    {
        public VBehaviorEvaluateService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override Task AddAsync(object request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VBehaviorEvaluate>> SearchBehaviorEvaluate(BehaviorEvaluateSearchRequest request)
        {
            var noteCriteriaIdParameter = new SqlParameter
            {
                ParameterName = "noteCriteriaId",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.BigInt,
                Value = request.NoteCriteriaId
            };

            var behaviorIdParameter = new SqlParameter
            {
                ParameterName = "behaviorId",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.BigInt,
                Value = request.BehaviorId
            };


            return await _repository.ExecWithStoreProcedure("dbo.sp_SearchBehaviorEvaluate @noteCriteriaId, @behaviorId", noteCriteriaIdParameter, behaviorIdParameter);
        }

        public override Task UpdateAsync(object request)
        {
            throw new NotImplementedException();
        }
    }
}

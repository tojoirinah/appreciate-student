using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;

namespace Appreciation.Manager.Services.Contracts.Mappers
{
    public static class BehaviorEvaluateMapper
    {
        public static void ProjectTo(this UpdateBehaviorEvaluateRequest request, BehaviorEvaluate behaviorEvaluate)
        {
            behaviorEvaluate.BehaviorId = request.BehaviorId;
            behaviorEvaluate.NoteCriteriaId = request.NoteCriteriaId;
            behaviorEvaluate.Evaluation = request.Evaluation;
        }

        public static BehaviorEvaluate ProjectTo(this AddBehaviorEvaluateRequest request, IMapper mapper)
        {
            BehaviorEvaluate item = mapper.Map<BehaviorEvaluate>(request);
            item.DateCreated = DateTime.Now;
            return item;
        }
    }
}

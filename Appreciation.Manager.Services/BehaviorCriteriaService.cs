﻿using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;

namespace Appreciation.Manager.Services
{
    public class BehaviorCriteriaService : Service<BehaviorCriteria>, IBehaviorCriteriaService
    {

        public BehaviorCriteriaService(IUnitOfWork unitOfWork, IBehaviorCriteriaRepository repository) : base(unitOfWork, repository)
        {
        }


    }
}
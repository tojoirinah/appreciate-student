﻿using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class VNoteCriteriaService : Service<VNoteCriteria>, IVNoteCriteriaService
    {
        public VNoteCriteriaService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override Task AddAsync(object request)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(object request)
        {
            throw new NotImplementedException();
        }
    }
}

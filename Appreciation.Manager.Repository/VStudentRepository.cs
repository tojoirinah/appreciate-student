﻿using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class VStudentRepository : Repository<VStudent>, IVStudentRepository
    {
        public VStudentRepository(AppreciationContext context) : base(context)
        {
        }
    }
}

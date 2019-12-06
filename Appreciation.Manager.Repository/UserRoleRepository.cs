﻿using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository
{
    public class UserRoleRepository : ReadOnlyRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AppreciationContext unitOfWork) : base(unitOfWork)
        {

        }
    }

}

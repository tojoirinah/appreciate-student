﻿using System.Data.Entity;
using System.Threading.Tasks;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<Users> GetUserName(string username)
        {
            return await _table.FirstOrDefaultAsync(itm => itm.UserName == username);
        }
    }
}

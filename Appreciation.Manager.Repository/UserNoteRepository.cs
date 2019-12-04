﻿using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class UserNoteRepository : Repository<UserNote>, IUserNoteRepository
    {
        public UserNoteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
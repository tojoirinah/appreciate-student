using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Services.Contracts.Mappers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class ClassroomService : Service<Classroom>, IClassroomService
    {
        public ClassroomService(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
        }

        public async override Task<IEnumerable<Classroom>> GetAllAsync()
        {
            return await _repository.GetAllDataAsync(x => !x.SchoolYear.IsClosed, new string[] { "SchoolYear" });
        }

        public async override Task<Classroom> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "SchoolYear" });
        }

        public override async Task AddAsync(object request)
        {
            if (!(request is AddClassroomRequest))
                throw new Exception("Convert type not allowed");

            AddClassroomRequest rq = (AddClassroomRequest)request;
            var cr = rq.ProjectTo(_mapper);

            // update student
            await _repository.AddOrUpdateAsync(cr);
        }

        public async override Task UpdateAsync(object request)
        {
            if (!(request is UpdateClassroomRequest))
                throw new Exception("Convert type not allowed");

            UpdateClassroomRequest req = (UpdateClassroomRequest)request;

            Classroom cr = await _repository.GetByIdAsync(req.Id);
            if (cr == null)
                throw new Exception("Classroom not found");

            req.ProjectTo(cr);

            await _repository.AddOrUpdateAsync(cr);
        }
    }
}

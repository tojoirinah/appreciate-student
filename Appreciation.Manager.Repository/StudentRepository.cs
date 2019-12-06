using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Infrastructure;

namespace Appreciation.Manager.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppreciationContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}

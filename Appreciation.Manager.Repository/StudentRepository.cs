using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppreciationContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}

using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class StudentSchoolYearService : Service<StudentSchoolYear>, IStudentSchoolYearService
    {
        protected IStudentSchoolYearRepository _repository;
        public StudentSchoolYearService(IUnitOfWork unitOfWork, IStudentSchoolYearRepository repository) : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task RemoveAllStudentSchoolYearByStudentId(long studentId)
        {
            await _repository.RemoveByStudentId(studentId);
        }
    }
}

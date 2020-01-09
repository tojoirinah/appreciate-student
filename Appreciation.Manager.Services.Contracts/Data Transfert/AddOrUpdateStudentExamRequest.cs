using Appreciation.Manager.Utils.Attributes;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class StudentExamRequest : Request
    {
        [IdentityValidation]
        public long Id { get; set; }

        [IdentityValidation]
        public long StudentId { get; set; }

        public bool IsAbsent { get; set; }

        public double? Note { get; set; }

        [IdentityValidation]
        public long BehaviorId { get; set; }

        [IdentityValidation]
        public long ExamId { get; set; }

        public bool IsClosed { get; set; }

    }

    public class StudentExamSearchRequest : Request
    {
        public long SchoolYearId { get; set; }

        public long ClassroomId { get; set; }

        public long ExamId { get; set; }

        public bool IsAbsent { get; set; }
    }
}

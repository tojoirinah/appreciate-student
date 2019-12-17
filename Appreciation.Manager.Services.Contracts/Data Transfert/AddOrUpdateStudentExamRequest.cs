namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddStudentExamRequest : Request
    {
        public long StudentId { get; set; }

        public bool IsAbsent { get; set; }

        public double? Note { get; set; }

        public long BehaviorId { get; set; }

        public long ExamId { get; set; }

        public bool IsClosed { get; set; }

    }

    public class UpdateStudentExamRequest : Request
    {
        public long Id { get; set; }

        public long StudentId { get; set; }

        public bool IsAbsent { get; set; }

        public double? Note { get; set; }

        public long BehaviorId { get; set; }

        public long ExamId { get; set; }

        public bool IsClosed { get; set; }

    }
}

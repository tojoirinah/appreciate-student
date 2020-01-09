using System.Collections.Generic;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class DashboardDto
    {
        public IList<SchoolYearDto> SchoolYears { get; set; }

        public DashboardDto()
        {
            SchoolYears = new List<SchoolYearDto>();
        }
    }

    public class SchoolYearDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public IList<ClassroomDto> Classrooms { get; set; }

        public SchoolYearDto(long id, string name)
        {
            Id = id;
            Name = name;
            Classrooms = new List<ClassroomDto>();
        }
    }

    public class ClassroomDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public IList<ExamDto> Exams { get; set; }

        public ClassroomDto(long id, string name)
        {
            Id = id;
            Name = name;
            Exams = new List<ExamDto>();
        }
    }

    public class ExamDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int TotalStudents { get; set; }
        public int TotalAbsents { get; set; }
        public int TotalWaitingNonReseigne { get; set; }
        public decimal PercentNoteRenseigne { get; set; }

        public ExamDto(long id, string name, int totalStudents, int totalAbsents, int totalWaitingNonReseigne, decimal percentNoteRenseigne)
        {
            Id = id;
            Name = name;
            TotalStudents = totalStudents;
            TotalAbsents = totalAbsents;
            TotalWaitingNonReseigne = totalWaitingNonReseigne;
            PercentNoteRenseigne = percentNoteRenseigne;
        }

    }
}

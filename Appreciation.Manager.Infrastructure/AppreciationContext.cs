using Appreciation.Manager.Infrastructure.Models;
using System.Data.Entity;

namespace Appreciation.Manager.Infrastructure
{
    public class AppreciationContext : DbContext
    {
        public virtual DbSet<Behavior> Behaviors { get; set; }
        public virtual DbSet<BehaviorEvaluate> BehaviorEvaluates { get; set; }
        public virtual DbSet<Classroom> Classrooms { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<NoteCriteria> NoteCriterias { get; set; }
        public virtual DbSet<NoteEvaluate> NoteEvaluates { get; set; }
        public virtual DbSet<SchoolYear> SchoolYears { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentExam> StudentExams { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VStudent> VStudents { get; set; }
        public virtual DbSet<VNoteEvaluate> VNoteEvaluates { get; set; }
        public virtual DbSet<VBehaviorEvaluate> VBehaviorEvaluates { get; set; }
        public virtual DbSet<VDashboardExam> VDashboardExams { get; set; }
        public virtual DbSet<VBehavior> VBehaviors { get; set; }
        public virtual DbSet<VClassroom> VClassrooms { get; set; }
        public virtual DbSet<VNoteCriteria> VNoteCriterias { get; set; }
        public virtual DbSet<VSchoolYear> VSchoolYears { get; set; }
        public virtual DbSet<VExam> VExams { get; set; }

        public AppreciationContext() : base("AppreciationContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppreciationContext>());

        }

        public bool IsDisposed { get; set; }
        //public new void Dispose()
        //{
        //    IsDisposed = true;
        //    base.Dispose();
        //}

    }
}

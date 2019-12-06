using Appreciation.Manager.Infrastructure.Models;
using System.Data.Entity;

namespace Appreciation.Manager.Infrastructure
{
    public class AppreciationContext : DbContext
    {
        public virtual DbSet<Behavior> Behaviors { get; set; }
        public virtual DbSet<BehaviorCriteria> BehaviorCriterias { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<NoteCriteria> NoteCriterias { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public AppreciationContext() : base("name=AppreciationContext")
        {

        }

        public bool IsDisposed { get; set; }
        //public new void Dispose()
        //{
        //    IsDisposed = true;
        //    base.Dispose();
        //}

    }
}

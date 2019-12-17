namespace Appreciation.Manager.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BehaviorEvaluate",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    BehaviorId = c.Long(nullable: false),
                    NoteCriteriaId = c.Long(nullable: false),
                    Evaluation = c.String(),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Behavior", t => t.BehaviorId, cascadeDelete: true)
                .ForeignKey("dbo.NoteCriteria", t => t.NoteCriteriaId, cascadeDelete: true)
                .Index(t => t.BehaviorId)
                .Index(t => t.NoteCriteriaId);

            CreateTable(
                "dbo.Behavior",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Value = c.Int(nullable: false),
                    Description = c.String(unicode: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.NoteCriteria",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Min = c.Double(nullable: false),
                    Max = c.Double(nullable: false),
                    Description = c.String(unicode: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Classroom",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    ClassNumber = c.String(maxLength: 20, unicode: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Exam",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(maxLength: 50),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.NoteEvaluate",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    NoteCriteriaId = c.Long(nullable: false),
                    Evaluation = c.String(unicode: false),
                    Advice = c.String(unicode: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NoteCriteria", t => t.NoteCriteriaId, cascadeDelete: true)
                .Index(t => t.NoteCriteriaId);

            CreateTable(
                "dbo.SchoolYear",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 10, unicode: false),
                    IsClosed = c.Boolean(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.StudentExam",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    StudentId = c.Long(nullable: false),
                    IsAbsent = c.Boolean(nullable: false),
                    Note = c.Double(),
                    BehaviorId = c.Long(nullable: false),
                    ExamId = c.Long(nullable: false),
                    IsClosed = c.Boolean(nullable: false),
                    NoteEvaluate = c.String(unicode: false),
                    BehaviorEvaluate = c.String(unicode: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Behavior", t => t.BehaviorId, cascadeDelete: true)
                .ForeignKey("dbo.Exam", t => t.ExamId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.BehaviorId)
                .Index(t => t.ExamId)
                .Index(t => t.StudentId);

            CreateTable(
                "dbo.Student",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    SchoolYearId = c.Long(nullable: false),
                    ClassRoomId = c.Long(nullable: false),
                    Age = c.Int(nullable: false),
                    Civility = c.Int(nullable: false),
                    UserId = c.Long(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolYear", t => t.SchoolYearId, cascadeDelete: true)
                .ForeignKey("dbo.Classroom", t => t.ClassRoomId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SchoolYearId)
                .Index(t => t.ClassRoomId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.User",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100, unicode: false),
                    FirstName = c.String(maxLength: 100, unicode: false),
                    UserName = c.String(maxLength: 100, unicode: false),
                    Security_salt = c.String(nullable: false, maxLength: 500, unicode: false),
                    Password = c.String(nullable: false, maxLength: 500, unicode: false),
                    RoleId = c.Long(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Role",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    RoleName = c.String(nullable: false, maxLength: 50, unicode: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.StudentExam", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Student", "ClassRoomId", "dbo.Classroom");
            DropForeignKey("dbo.Student", "SchoolYearId", "dbo.SchoolYear");
            DropForeignKey("dbo.StudentExam", "ExamId", "dbo.Exam");
            DropForeignKey("dbo.StudentExam", "BehaviorId", "dbo.Behavior");
            DropForeignKey("dbo.NoteEvaluate", "NoteCriteriaId", "dbo.NoteCriteria");
            DropForeignKey("dbo.BehaviorEvaluate", "NoteCriteriaId", "dbo.NoteCriteria");
            DropForeignKey("dbo.BehaviorEvaluate", "BehaviorId", "dbo.Behavior");
            DropIndex("dbo.StudentExam", new[] { "StudentId" });
            DropIndex("dbo.Student", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "RoleId" });
            DropIndex("dbo.Student", new[] { "ClassRoomId" });
            DropIndex("dbo.Student", new[] { "SchoolYearId" });
            DropIndex("dbo.StudentExam", new[] { "ExamId" });
            DropIndex("dbo.StudentExam", new[] { "BehaviorId" });
            DropIndex("dbo.NoteEvaluate", new[] { "NoteCriteriaId" });
            DropIndex("dbo.BehaviorEvaluate", new[] { "NoteCriteriaId" });
            DropIndex("dbo.BehaviorEvaluate", new[] { "BehaviorId" });
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Student");
            DropTable("dbo.StudentExam");
            DropTable("dbo.SchoolYear");
            DropTable("dbo.NoteEvaluate");
            DropTable("dbo.Exam");
            DropTable("dbo.Classroom");
            DropTable("dbo.NoteCriteria");
            DropTable("dbo.Behavior");
            DropTable("dbo.BehaviorEvaluate");
        }
    }
}

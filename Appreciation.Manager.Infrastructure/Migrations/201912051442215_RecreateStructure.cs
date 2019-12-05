namespace Appreciation.Manager.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateStructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BehaviorCriteria",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Criteria = c.Int(nullable: false),
                        Evaluate = c.String(unicode: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Behavior",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.Int(nullable: false),
                        Description = c.String(unicode: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NoteCriteria",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Min = c.Double(nullable: false),
                        Max = c.Double(nullable: false),
                        Evaluate = c.String(unicode: false),
                        Conseils = c.String(unicode: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Age = c.Int(nullable: false),
                        Civility = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserNote",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SubjectId = c.Guid(nullable: false),
                        Note = c.Double(nullable: false),
                        Behavior = c.Int(nullable: false),
                        ExamId = c.Guid(nullable: false),
                        UserEvaluateId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Student_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exam", t => t.ExamId, cascadeDelete: true)
                .ForeignKey("dbo.UserEvaluate", t => t.UserEvaluateId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.Student_Id)
                .Index(t => t.ExamId)
                .Index(t => t.UserEvaluateId)
                .Index(t => t.SubjectId)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.UserEvaluate",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NoteEvaluation = c.String(),
                        BehaviorEvaluation = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserNote", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.UserNote", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.UserNote", "UserEvaluateId", "dbo.UserEvaluate");
            DropForeignKey("dbo.UserNote", "ExamId", "dbo.Exam");
            DropIndex("dbo.Student", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "RoleId" });
            DropIndex("dbo.UserNote", new[] { "Student_Id" });
            DropIndex("dbo.UserNote", new[] { "SubjectId" });
            DropIndex("dbo.UserNote", new[] { "UserEvaluateId" });
            DropIndex("dbo.UserNote", new[] { "ExamId" });
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Subject");
            DropTable("dbo.UserEvaluate");
            DropTable("dbo.UserNote");
            DropTable("dbo.Student");
            DropTable("dbo.NoteCriteria");
            DropTable("dbo.Exam");
            DropTable("dbo.Behavior");
            DropTable("dbo.BehaviorCriteria");
        }
    }
}

namespace Appreciation.Manager.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BehaviorCriteria",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Criteria = c.Int(nullable: false),
                    Evaluate = c.String(maxLength: 8000, unicode: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Behavior",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Value = c.Int(nullable: false),
                    Description = c.String(maxLength: 8000, unicode: false),
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
                    Evaluate = c.String(maxLength: 8000, unicode: false),
                    Conseils = c.String(maxLength: 8000, unicode: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Student",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                    Setting_Id = c.Guid(),
                    User_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSetting", t => t.Setting_Id)
                .ForeignKey("dbo.tb_User", t => t.User_Id)
                .Index(t => t.Setting_Id)
                .Index(t => t.User_Id);

            CreateTable(
                "dbo.UserNote",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Note = c.Double(nullable: false),
                    Behavior = c.Int(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                    ControlContinu_Id = c.Guid(),
                    Evaluate_Id = c.Guid(),
                    Matiere_Id = c.Guid(),
                    Student_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exam", t => t.ControlContinu_Id)
                .ForeignKey("dbo.UserEvaluate", t => t.Evaluate_Id)
                .ForeignKey("dbo.Subject", t => t.Matiere_Id)
                .ForeignKey("dbo.Student", t => t.Student_Id)
                .Index(t => t.ControlContinu_Id)
                .Index(t => t.Evaluate_Id)
                .Index(t => t.Matiere_Id)
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
                "dbo.UserSetting",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Age = c.Int(nullable: false),
                    Civility = c.Int(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.tb_User",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 100, unicode: false),
                    FirstName = c.String(maxLength: 100, unicode: false),
                    Security_salt = c.String(nullable: false, maxLength: 500, unicode: false),
                    Password = c.String(nullable: false, maxLength: 500, unicode: false),
                    RoleId = c.Guid(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Role",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    RoleName = c.String(nullable: false, maxLength: 50, unicode: false),
                    Identity = c.Int(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Student", "User_Id", "dbo.tb_User");
            DropForeignKey("dbo.tb_User", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Student", "Setting_Id", "dbo.UserSetting");
            DropForeignKey("dbo.UserNote", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.UserNote", "Matiere_Id", "dbo.Subject");
            DropForeignKey("dbo.UserNote", "Evaluate_Id", "dbo.UserEvaluate");
            DropForeignKey("dbo.UserNote", "ControlContinu_Id", "dbo.Exam");
            DropIndex("dbo.tb_User", new[] { "RoleId" });
            DropIndex("dbo.UserNote", new[] { "Student_Id" });
            DropIndex("dbo.UserNote", new[] { "Matiere_Id" });
            DropIndex("dbo.UserNote", new[] { "Evaluate_Id" });
            DropIndex("dbo.UserNote", new[] { "ControlContinu_Id" });
            DropIndex("dbo.Student", new[] { "User_Id" });
            DropIndex("dbo.Student", new[] { "Setting_Id" });
            DropTable("dbo.Role");
            DropTable("dbo.tb_User");
            DropTable("dbo.UserSetting");
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

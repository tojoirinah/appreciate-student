namespace Appreciation.Manager.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUsername_to_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserNote", "ControlContinu_Id", "dbo.Exam");
            DropForeignKey("dbo.UserNote", "Evaluate_Id", "dbo.UserEvaluate");
            DropForeignKey("dbo.UserNote", "Matiere_Id", "dbo.Subject");
            DropForeignKey("dbo.Student", "User_Id", "dbo.tb_User");
            DropIndex("dbo.UserNote", new[] { "ControlContinu_Id" });
            DropIndex("dbo.UserNote", new[] { "Evaluate_Id" });
            DropIndex("dbo.UserNote", new[] { "Matiere_Id" });
            DropIndex("dbo.Student", new[] { "User_Id" });
            RenameColumn(table: "dbo.UserNote", name: "ControlContinu_Id", newName: "ExamId");
            RenameColumn(table: "dbo.UserNote", name: "Evaluate_Id", newName: "UserEvaluateId");
            RenameColumn(table: "dbo.UserNote", name: "Matiere_Id", newName: "SubjectId");
            RenameColumn(table: "dbo.Student", name: "User_Id", newName: "UserId");
            AddColumn("dbo.tb_User", "UserName", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Student", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserNote", "ExamId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserNote", "UserEvaluateId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserNote", "SubjectId", c => c.Guid(nullable: false));
            CreateIndex("dbo.UserNote", "ExamId");
            CreateIndex("dbo.UserNote", "UserEvaluateId");
            CreateIndex("dbo.UserNote", "SubjectId");
            CreateIndex("dbo.Student", "UserId");
            AddForeignKey("dbo.UserNote", "ExamId", "dbo.Exam", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserNote", "UserEvaluateId", "dbo.UserEvaluate", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserNote", "SubjectId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Student", "UserId", "dbo.tb_User", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Student", "UserId", "dbo.tb_User");
            DropForeignKey("dbo.UserNote", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.UserNote", "UserEvaluateId", "dbo.UserEvaluate");
            DropForeignKey("dbo.UserNote", "ExamId", "dbo.Exam");
            DropIndex("dbo.Student", new[] { "UserId" });
            DropIndex("dbo.UserNote", new[] { "SubjectId" });
            DropIndex("dbo.UserNote", new[] { "UserEvaluateId" });
            DropIndex("dbo.UserNote", new[] { "ExamId" });
            AlterColumn("dbo.UserNote", "SubjectId", c => c.Guid());
            AlterColumn("dbo.UserNote", "UserEvaluateId", c => c.Guid());
            AlterColumn("dbo.UserNote", "ExamId", c => c.Guid());
            AlterColumn("dbo.Student", "UserId", c => c.Guid());
            DropColumn("dbo.tb_User", "UserName");
            RenameColumn(table: "dbo.Student", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.UserNote", name: "SubjectId", newName: "Matiere_Id");
            RenameColumn(table: "dbo.UserNote", name: "UserEvaluateId", newName: "Evaluate_Id");
            RenameColumn(table: "dbo.UserNote", name: "ExamId", newName: "ControlContinu_Id");
            CreateIndex("dbo.Student", "User_Id");
            CreateIndex("dbo.UserNote", "Matiere_Id");
            CreateIndex("dbo.UserNote", "Evaluate_Id");
            CreateIndex("dbo.UserNote", "ControlContinu_Id");
            AddForeignKey("dbo.Student", "User_Id", "dbo.tb_User", "Id");
            AddForeignKey("dbo.UserNote", "Matiere_Id", "dbo.Subject", "Id");
            AddForeignKey("dbo.UserNote", "Evaluate_Id", "dbo.UserEvaluate", "Id");
            AddForeignKey("dbo.UserNote", "ControlContinu_Id", "dbo.Exam", "Id");
        }
    }
}

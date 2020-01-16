namespace Appreciation.Manager.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class update_foreign_key_Exam : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exam", "SchoolYearId", "dbo.SchoolYear");
            DropIndex("dbo.Exam", new[] { "SchoolYearId" });
            AddColumn("dbo.Exam", "ClassroomId", c => c.Long(nullable: false));
            CreateIndex("dbo.Exam", "ClassroomId");
            AddForeignKey("dbo.Exam", "ClassroomId", "dbo.Classroom", "Id", cascadeDelete: false);
            DropColumn("dbo.Exam", "SchoolYearId");
        }

        public override void Down()
        {
            AddColumn("dbo.Exam", "SchoolYearId", c => c.Long(nullable: false));
            DropForeignKey("dbo.Exam", "ClassroomId", "dbo.Classroom");
            DropIndex("dbo.Exam", new[] { "ClassroomId" });
            DropColumn("dbo.Exam", "ClassroomId");
            CreateIndex("dbo.Exam", "SchoolYearId");
            AddForeignKey("dbo.Exam", "SchoolYearId", "dbo.SchoolYear", "Id", cascadeDelete: false);
        }
    }
}

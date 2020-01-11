namespace Appreciation.Manager.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_schoolyear_foreign_key_to_exam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exam", "SchoolYearId", c => c.Long(nullable: false));
            CreateIndex("dbo.Exam", "SchoolYearId");
            AddForeignKey("dbo.Exam", "SchoolYearId", "dbo.SchoolYear", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exam", "SchoolYearId", "dbo.SchoolYear");
            DropIndex("dbo.Exam", new[] { "SchoolYearId" });
            DropColumn("dbo.Exam", "SchoolYearId");
        }
    }
}

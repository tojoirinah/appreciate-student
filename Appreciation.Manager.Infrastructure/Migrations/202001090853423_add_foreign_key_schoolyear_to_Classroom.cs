namespace Appreciation.Manager.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class add_foreign_key_schoolyear_to_Classroom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classroom", "SchoolYearId", c => c.Long(nullable: false));
            CreateIndex("dbo.Classroom", "SchoolYearId");
            AddForeignKey("dbo.Classroom", "SchoolYearId", "dbo.SchoolYear", "Id", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Classroom", "SchoolYearId", "dbo.SchoolYear");
            DropIndex("dbo.Classroom", new[] { "SchoolYearId" });
            DropColumn("dbo.Classroom", "SchoolYearId");
        }
    }
}

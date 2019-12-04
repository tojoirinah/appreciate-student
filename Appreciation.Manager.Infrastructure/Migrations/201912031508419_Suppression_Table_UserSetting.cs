namespace Appreciation.Manager.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Suppression_Table_UserSetting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Student", "Setting_Id", "dbo.UserSetting");
            DropIndex("dbo.Student", new[] { "Setting_Id" });
            AddColumn("dbo.Student", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Student", "Civility", c => c.Int(nullable: false));
            AlterColumn("dbo.Student", "User_Id", c => c.Guid());
            AlterColumn("dbo.UserNote", "ControlContinu_Id", c => c.Guid());
            AlterColumn("dbo.UserNote", "Evaluate_Id", c => c.Guid());
            AlterColumn("dbo.UserNote", "Matiere_Id", c => c.Guid());
            AlterColumn("dbo.UserNote", "Student_Id", c => c.Guid());
            AlterColumn("dbo.tb_User", "RoleId", c => c.Guid(nullable: false));
            DropColumn("dbo.Student", "Setting_Id");
            DropTable("dbo.UserSetting");
        }

        public override void Down()
        {
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

            AddColumn("dbo.Student", "Setting_Id", c => c.Guid());
            AlterColumn("dbo.tb_User", "RoleId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserNote", "Student_Id", c => c.Guid());
            AlterColumn("dbo.UserNote", "Matiere_Id", c => c.Guid());
            AlterColumn("dbo.UserNote", "Evaluate_Id", c => c.Guid());
            AlterColumn("dbo.UserNote", "ControlContinu_Id", c => c.Guid());
            AlterColumn("dbo.Student", "User_Id", c => c.Guid());
            DropColumn("dbo.Student", "Civility");
            DropColumn("dbo.Student", "Age");
            CreateIndex("dbo.Student", "Setting_Id");
            AddForeignKey("dbo.Student", "Setting_Id", "dbo.UserSetting", "Id");
        }
    }
}

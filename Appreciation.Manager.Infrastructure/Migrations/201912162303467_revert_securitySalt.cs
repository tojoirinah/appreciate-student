namespace Appreciation.Manager.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class revert_securitySalt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "SecuritySalt", c => c.String(nullable: false, unicode: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.User", "SecuritySalt", c => c.String(unicode: false));
        }
    }
}

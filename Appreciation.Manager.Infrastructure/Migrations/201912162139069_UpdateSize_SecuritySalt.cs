namespace Appreciation.Manager.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateSize_SecuritySalt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Security_salt", c => c.String(nullable: false, unicode: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.User", "Security_salt", c => c.String(nullable: false, maxLength: 500, unicode: false));
        }
    }
}

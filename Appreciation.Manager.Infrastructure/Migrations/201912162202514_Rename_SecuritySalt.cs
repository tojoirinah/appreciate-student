namespace Appreciation.Manager.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Rename_SecuritySalt : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.User", name: "Security_salt", newName: "SecuritySalt");
        }

        public override void Down()
        {
            RenameColumn(table: "dbo.User", name: "SecuritySalt", newName: "Security_salt");
        }
    }
}

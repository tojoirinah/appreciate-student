namespace Appreciation.Manager.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Create_Structure_02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BehaviorCriteria",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Criteria = c.Int(nullable: false),
                    Evaluate = c.String(unicode: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Behavior",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Value = c.Int(nullable: false),
                    Description = c.String(unicode: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Exam",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Number = c.Int(nullable: false),
                    Name = c.String(),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.NoteCriteria",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
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
                    Id = c.Long(nullable: false, identity: true),
                    Age = c.Int(nullable: false),
                    Civility = c.Int(nullable: false),
                    UserId = c.Long(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.User",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
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
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Student", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropIndex("dbo.Student", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "RoleId" });
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Student");
            DropTable("dbo.NoteCriteria");
            DropTable("dbo.Exam");
            DropTable("dbo.Behavior");
            DropTable("dbo.BehaviorCriteria");
        }
    }
}

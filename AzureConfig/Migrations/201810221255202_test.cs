using System.Data.Entity.Migrations;

namespace AzureConfig.Migrations
{
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConnectionStrings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        CreatedAtUtc = c.DateTime(nullable: false),
                        Environment = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConnectionStrings");
        }
    }
}

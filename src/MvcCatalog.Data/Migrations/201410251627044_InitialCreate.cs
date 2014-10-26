namespace MvcCatalog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Email = c.String(nullable: false, maxLength: 160),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 32, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "IX_USER_EMAIL")
                .Index(t => t.Username, unique: true, name: "IX_USER_USERNAME");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", "IX_USER_USERNAME");
            DropIndex("dbo.User", "IX_USER_EMAIL");
            DropTable("dbo.User");
        }
    }
}

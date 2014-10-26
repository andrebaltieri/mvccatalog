namespace MvcCatalog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionado_Campo_Imagem_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Image");
        }
    }
}

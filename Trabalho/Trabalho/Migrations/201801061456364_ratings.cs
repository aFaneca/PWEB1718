namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instituicaos", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Instituicaos", "Avalicaoes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instituicaos", "Avalicaoes");
            DropColumn("dbo.Instituicaos", "Rating");
        }
    }
}

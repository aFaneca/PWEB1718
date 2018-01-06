namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hehehehe9111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instituicaos", "RatingMedio", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instituicaos", "RatingMedio");
        }
    }
}

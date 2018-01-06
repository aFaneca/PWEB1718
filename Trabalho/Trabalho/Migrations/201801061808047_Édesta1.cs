namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Édesta1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instituicaos", "RatingMedio", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instituicaos", "RatingMedio", c => c.Double(nullable: false));
        }
    }
}

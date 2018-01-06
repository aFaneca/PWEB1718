namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ÉagoraSIIM1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Instituicaos", "RatingMedio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instituicaos", "RatingMedio", c => c.Double());
        }
    }
}

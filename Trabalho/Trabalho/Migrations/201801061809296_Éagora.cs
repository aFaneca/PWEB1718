namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Éagora : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instituicaos", "RatingMedio", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instituicaos", "RatingMedio", c => c.Int());
        }
    }
}

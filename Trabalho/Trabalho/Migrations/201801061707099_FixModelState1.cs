namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModelState1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instituicaos", "PontuacaoTotal", c => c.Int());
            AlterColumn("dbo.Instituicaos", "Rating", c => c.Int());
            AlterColumn("dbo.Instituicaos", "Avaliacoes", c => c.Int());
            AlterColumn("dbo.Instituicaos", "RatingMedio", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instituicaos", "RatingMedio", c => c.Double(nullable: false));
            AlterColumn("dbo.Instituicaos", "Avaliacoes", c => c.Int(nullable: false));
            AlterColumn("dbo.Instituicaos", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Instituicaos", "PontuacaoTotal", c => c.Int(nullable: false));
        }
    }
}

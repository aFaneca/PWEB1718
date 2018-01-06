namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Édesta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instituicaos", "PontuacaoTotal", c => c.Int(nullable: false));
            AlterColumn("dbo.Instituicaos", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Instituicaos", "Avaliacoes", c => c.Int(nullable: false));
            AlterColumn("dbo.Instituicaos", "RatingMedio", c => c.Double(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instituicaos", "RatingMedio", c => c.Double());
            AlterColumn("dbo.Instituicaos", "Avaliacoes", c => c.Int());
            AlterColumn("dbo.Instituicaos", "Rating", c => c.Int());
            AlterColumn("dbo.Instituicaos", "PontuacaoTotal", c => c.Int());
        }
    }
}

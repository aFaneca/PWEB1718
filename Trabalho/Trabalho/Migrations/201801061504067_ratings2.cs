namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratings2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instituicaos", "PontuacaoTotal", c => c.Int(nullable: false));
            AddColumn("dbo.Instituicaos", "Avaliacoes", c => c.Int(nullable: false));
            AddColumn("dbo.Instituicaos", "RatingMedio", c => c.Double(nullable: false));
            DropColumn("dbo.Instituicaos", "Avalicaoes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instituicaos", "Avalicaoes", c => c.Int(nullable: false));
            DropColumn("dbo.Instituicaos", "RatingMedio");
            DropColumn("dbo.Instituicaos", "Avaliacoes");
            DropColumn("dbo.Instituicaos", "PontuacaoTotal");
        }
    }
}

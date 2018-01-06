namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1ToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Criancas",
                c => new
                    {
                        CriancaId = c.Int(nullable: false, identity: true),
                        Idade = c.Int(nullable: false),
                        Nome = c.String(),
                        UserId = c.String(),
                        InstituicaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CriancaId)
                .ForeignKey("dbo.Instituicaos", t => t.InstituicaoId, cascadeDelete: true)
                .Index(t => t.InstituicaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Criancas", "InstituicaoId", "dbo.Instituicaos");
            DropIndex("dbo.Criancas", new[] { "InstituicaoId" });
            DropTable("dbo.Criancas");
        }
    }
}

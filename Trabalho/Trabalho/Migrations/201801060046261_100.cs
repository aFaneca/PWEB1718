namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _100 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Criancas", "InstituicaoId", "dbo.Instituicaos");
            DropIndex("dbo.Criancas", new[] { "InstituicaoId" });
            CreateTable(
                "dbo.Candidaturas",
                c => new
                    {
                        CandidaturaId = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                        CriancaId = c.Int(nullable: false),
                        InstituicaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CandidaturaId)
                .ForeignKey("dbo.Instituicaos", t => t.InstituicaoId, cascadeDelete: true)
                .Index(t => t.InstituicaoId);
            
            AddColumn("dbo.Criancas", "CandidaturaId", c => c.Int());
            CreateIndex("dbo.Criancas", "CandidaturaId");
            AddForeignKey("dbo.Criancas", "CandidaturaId", "dbo.Candidaturas", "CandidaturaId");
            DropColumn("dbo.Criancas", "InstituicaoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Criancas", "InstituicaoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Candidaturas", "InstituicaoId", "dbo.Instituicaos");
            DropForeignKey("dbo.Criancas", "CandidaturaId", "dbo.Candidaturas");
            DropIndex("dbo.Candidaturas", new[] { "InstituicaoId" });
            DropIndex("dbo.Criancas", new[] { "CandidaturaId" });
            DropColumn("dbo.Criancas", "CandidaturaId");
            DropTable("dbo.Candidaturas");
            CreateIndex("dbo.Criancas", "InstituicaoId");
            AddForeignKey("dbo.Criancas", "InstituicaoId", "dbo.Instituicaos", "ID", cascadeDelete: true);
        }
    }
}

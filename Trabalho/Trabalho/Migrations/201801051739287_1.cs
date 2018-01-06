namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instituicaos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Creche = c.Boolean(nullable: false),
                        PreEscolar = c.Boolean(nullable: false),
                        TransporteCriancas = c.Boolean(nullable: false),
                        AulasNatacao = c.Boolean(nullable: false),
                        AulasMusica = c.Boolean(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Instituicaos");
        }
    }
}

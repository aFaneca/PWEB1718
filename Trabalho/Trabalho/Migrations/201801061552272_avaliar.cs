namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class avaliar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidaturas", "Avaliacao", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidaturas", "Avaliacao");
        }
    }
}

namespace Trabalho.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModelState : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Candidaturas", "Avaliacao", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Candidaturas", "Avaliacao", c => c.Int(nullable: false));
        }
    }
}

namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientsAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fin_Clients", "ADDRESS", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fin_Clients", "ADDRESS");
        }
    }
}

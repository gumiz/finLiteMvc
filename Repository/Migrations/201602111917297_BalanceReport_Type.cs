namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BalanceReport_Type : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fin_Reports_Balance", "TYPE", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fin_Reports_Balance", "TYPE");
        }
    }
}

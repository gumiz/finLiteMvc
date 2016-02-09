namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfitAndLossReport_BoldColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fin_Reports_ProfitLoss", "BOLD", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fin_Reports_ProfitLoss", "BOLD");
        }
    }
}

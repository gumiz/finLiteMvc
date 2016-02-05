namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfitAndLossReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fin_Reports_ProfitLoss",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NUMBER = c.String(nullable: false),
                        DESCRIPTION = c.String(nullable: false),
                        FORMULA = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fin_Reports_ProfitLoss");
        }
    }
}

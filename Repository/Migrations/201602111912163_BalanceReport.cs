namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BalanceReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fin_Reports_Balance",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CLIENT_ID = c.Int(nullable: false),
                        ROW_ID = c.Int(nullable: false),
                        NUMBER = c.String(nullable: false),
                        DESCRIPTION = c.String(nullable: false),
                        FORMULA = c.String(),
                        READONLY = c.Boolean(nullable: false),
                        BOLD = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.CLIENT_ID });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fin_Reports_Balance");
        }
    }
}

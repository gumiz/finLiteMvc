namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BalanceReport_NumberNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fin_Reports_Balance", "NUMBER", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fin_Reports_Balance", "NUMBER", c => c.String(nullable: false));
        }
    }
}

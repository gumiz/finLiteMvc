using System.Data.Entity;
using Repository.Migrations;

namespace Repository.DAL
{
	public class DefaultContext : DbContext
	{
		public DefaultContext(): base("PostgresConnection")
		{
			//			Database.SetInitializer<DefaultContext>(new CreateDatabaseIfNotExists<DefaultContext>());
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefaultContext, Configuration>("PostgresConnection"));
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AccountDao>().HasKey(c => new {c.Name, c.ClientId, c.Year});
			modelBuilder.Entity<ClientDao>().HasKey(c => new {c.ClientId, c.Name});
			modelBuilder.Entity<OpeningDao>().HasKey(c => new {c.Year, c.ClientId, c.Name});
			modelBuilder.Entity<DocumentDao>().HasKey(c => new {c.Year, c.ClientId, c.Number, c.AutoNumber});
			modelBuilder.Entity<ProfitAndLossReportItemDao>().HasKey(c => new {c.Id, c.ClientId});
			modelBuilder.Entity<BalanceReportItemDao>().HasKey(c => new {c.Id, c.ClientId});
		}

		public DbSet<AccountDao> Accounts{ get; set; }
		public DbSet<ClientDao> Clients { get; set; }
		public DbSet<OpeningDao> Openings { get; set; }
		public DbSet<DocumentDao> Documents { get; set; }
		public DbSet<ProfitAndLossReportItemDao> ProfitLossReport {get; set; }
		public DbSet<BalanceReportItemDao> BalanceReport {get; set; }
	}
}
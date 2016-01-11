using System.Data.Entity;

namespace Repository.DAL
{
	public class DefaultContext : DbContext
	{
		public DefaultContext()
			: base("defaultConnectionFactory")
		{
			Database.SetInitializer<DefaultContext>(new CreateDatabaseIfNotExists<DefaultContext>());
//			Database.SetInitializer<DefaultContext>(new DropCreateDatabaseIfModelChanges<DefaultContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AccountDao>().HasKey(c => new {c.Name, c.ClientId});
			modelBuilder.Entity<ClientDao>().HasKey(c => new {c.ClientId, c.Name});
			modelBuilder.Entity<OpeningDao>().HasKey(c => new {c.Year, c.ClientId, c.Name});
			modelBuilder.Entity<DocumentDao>().HasKey(c => new {c.Year, c.ClientId, c.Number, c.AutoNumber});

//			modelBuilder.Entity<DysponentDao>().HasRequired<DysponentGroupDao>(x => x.DysponentGroup)
//			.WithMany(y => y.Dysponents)
//			.HasForeignKey(x => x.Group);
		}

		public DbSet<AccountDao> Accounts{ get; set; }
		public DbSet<ClientDao> Clients { get; set; }
		public DbSet<OpeningDao> Openings { get; set; }
		public DbSet<DocumentDao> Documents { get; set; }
	}
}
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

//			modelBuilder.Entity<DysponentDao>().HasRequired<DysponentGroupDao>(x => x.DysponentGroup)
//			.WithMany(y => y.Dysponents)
//			.HasForeignKey(x => x.Group);
		}

		public DbSet<AccountDao> AccountDao{ get; set; }
		public DbSet<ClientDao> ClientDao { get; set; }
		public DbSet<OpeningDao> OpeningDao { get; set; }
	}
}
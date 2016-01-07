using System.Data.Entity;

namespace Repository.DAL
{
	public class DefaultContext : DbContext
	{
		public DefaultContext()
			: base("defaultConnectionFactory")
		{
//			Database.SetInitializer<DefaultContext>(new CreateDatabaseIfNotExists<DefaultContext>());
			Database.SetInitializer<DefaultContext>(new DropCreateDatabaseIfModelChanges<DefaultContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{

//			modelBuilder.Entity<DysponentDao>().HasRequired<DysponentGroupDao>(x => x.DysponentGroup)
//			.WithMany(y => y.Dysponents)
//			.HasForeignKey(x => x.Group);
		}

		public DbSet<AccountDao> AccountDao{ get; set; }
	}
}
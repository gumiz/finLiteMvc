using Repository.Abstract;
using Repository.DAL;
using Repository.Services;

namespace Repository
{
	public class Factory : IFactory
	{
		public Factory()
		{
			var dbContext = new DefaultContext();
			AccountsService = new AccountsService(dbContext);
		}

		public AccountsService AccountsService { get; set; }

		public IAccountsService GetAccoutnsService()
		{
			return AccountsService;
		}
	}
}
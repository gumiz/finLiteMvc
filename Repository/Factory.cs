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
			ClientsService = new ClientsService(dbContext);
		}

		public AccountsService AccountsService { get; set; }
		public IClientsService ClientsService { get; set; }

		public IAccountsService GetAccoutnsService()
		{
			return AccountsService;
		}

		public IClientsService GetClientsService()
		{
			return ClientsService;
		}

	}
}
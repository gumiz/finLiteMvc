using Repository.Abstract;
using Repository.Services;

namespace Repository
{
	public class Factory : IFactory
	{
		public Factory()
		{
			AccountsService = new AccountsService();
		}

		public AccountsService AccountsService { get; set; }

		public IAccountsService GetAccoutnsService()
		{
			return AccountsService;
		}
	}
}
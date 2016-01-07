namespace Repository.Abstract
{
	public interface IFactory
	{
		IAccountsService GetAccoutnsService();
		IClientsService GetClientsService();
	}
}
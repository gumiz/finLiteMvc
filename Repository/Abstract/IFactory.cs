namespace Repository.Abstract
{
	public interface IFactory
	{
		IAccountsService GetAccoutnsService();
		IClientsService GetClientsService();
		IOpeningsService GetOpeningsService();
		IDataInitializatorService GetDataInitializatorService();
		IDocumentsService GetDocumentsService();
		IReportsService GetReportsService();
		IPrintService GetAccountsPrintService();
		IPrintService GetOpeningsPrintService();
	}
}
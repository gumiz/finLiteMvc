using Repository.DAL;

namespace Repository.Abstract
{
	public interface IFactory
	{
		DefaultContext GetDbContext();
		IAccountsService GetAccoutnsService();
		IClientsService GetClientsService();
		IOpeningsService GetOpeningsService();
		IDataInitializatorService GetDataInitializatorService();
		IDocumentsService GetDocumentsService();
		IReportsService GetReportsService();
		IPrintService GetAccountsPrintService();
		IPrintService GetOpeningsPrintService();
		IPrintService GetDocumentsPrintService();
		IPrintService GetReportsPrintService();
		IProfitLossService GetProfitLossService();
		IPrintService GetProfitLossPrintService();
		IBalanceService GetBalanceService();
		IPrintService GetBalancePrintService();
	}
}
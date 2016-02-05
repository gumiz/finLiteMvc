using Repository.Abstract;
using Repository.DAL;
using Repository.Services;
using Repository.Services.Printing;

namespace Repository
{
	public class Factory : IFactory
	{
		public Factory()
		{
			var dbContext = new DefaultContext();
			AccountsService = new AccountsService(dbContext);
			ClientsService = new ClientsService(dbContext);
			OpeningsService = new OpeningsService(dbContext);
			DocumentsService = new DocumentsService(dbContext);
			ReportsService = new ReportsService(dbContext);
			DataInitializatorService = new DataInitializatorService(dbContext);
			ProfitLossService = new ProfitLossService(dbContext);
			AccountsPrintService = new AccountsPrintService(this);
			OpeningsPrintService = new OpeningsPrintService(this);
			DocumentsPrintService = new DocumentsPrintService(this);
			ReportsPrintService = new ReportsPrintService(this);
			ProfitLossPrintService = new ProfitAndLossPrintService(this);
		}

		public AccountsService AccountsService { get; set; }
		public IClientsService ClientsService { get; set; }
		public IOpeningsService OpeningsService { get; set; }
		public IDocumentsService DocumentsService { get; set; }
		public IReportsService ReportsService { get; set; }
		public IDataInitializatorService DataInitializatorService { get; set; }
		public IPrintService AccountsPrintService { get; set; }
		public IPrintService OpeningsPrintService { get; set; }
		public IPrintService DocumentsPrintService { get; set; }
		public IPrintService ReportsPrintService { get; set; }
		public IPrintService ProfitLossPrintService { get; set; }
		public IProfitLossService ProfitLossService { get; set; }

		public IAccountsService GetAccoutnsService()
		{
			return AccountsService;
		}

		public IClientsService GetClientsService()
		{
			return ClientsService;
		}

		public IOpeningsService GetOpeningsService()
		{
			return OpeningsService;
		}

		public IDataInitializatorService GetDataInitializatorService()
		{
			return DataInitializatorService;
		}

		public IDocumentsService GetDocumentsService()
		{
			return DocumentsService;
		}

		public IReportsService GetReportsService()
		{
			return ReportsService;
		}

		public IPrintService GetAccountsPrintService()
		{
			return AccountsPrintService;
		}

		public IPrintService GetOpeningsPrintService()
		{
			return OpeningsPrintService;
		}

		public IPrintService GetDocumentsPrintService()
		{
			return DocumentsPrintService;
		}

		public IPrintService GetReportsPrintService()
		{
			return ReportsPrintService;
		}

		public IProfitLossService GetProfitLossService()
		{
			return ProfitLossService;
		}

		public IPrintService GetProfitLossPrintService()
		{
			return ProfitLossPrintService;
		}
	}
}
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
			DbContext = new DefaultContext();
			AccountsService = new AccountsService(DbContext);
			ClientsService = new ClientsService(DbContext);
			OpeningsService = new OpeningsService(DbContext);
			DocumentsService = new DocumentsService(DbContext);
			ReportsService = new ReportsService(DbContext);
			DataInitializatorService = new DataInitializatorService(DbContext);
			ProfitLossService = new ProfitLossService(this);
			BalanceService = new BalanceService(this);
			AccountsPrintService = new AccountsPrintService(this);
			OpeningsPrintService = new OpeningsPrintService(this);
			DocumentsPrintService = new DocumentsPrintService(this);
			ReportsPrintService = new ReportsPrintService(this);
			ProfitLossPrintService = new ProfitAndLossPrintService(this);
			BalancePrintService = new BalancePrintService(this);
		}

		public DefaultContext DbContext { get; set; }
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
		public IBalanceService BalanceService { get; set; }
		public IPrintService BalancePrintService { get; set; }

		public DefaultContext GetDbContext()
		{
			return DbContext;
		}

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

		public IBalanceService GetBalanceService()
		{
			return BalanceService;
		}

		public IPrintService GetBalancePrintService()
		{
			return BalancePrintService;
		}
	}
}
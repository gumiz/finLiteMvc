using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Abstract;
using Repository.DAL;
using Repository.Domain;

namespace Repository.Services
{
	public class ReportsService : IReportsService
	{
		private readonly DefaultContext _dbContext;
		private List<Report> _result;
		private List<AccountDao> _accounts;
		private int _year;
		private int _clientId;
		private Report _report;
		private List<OpeningDao> _openings;
		private List<DocumentDao> _documents;

		public ReportsService(DefaultContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<Report> GetReports(int year, int clientId)
		{
			_year = year;
			_clientId = clientId;

			PrepareReport();
			GetAccounts();

			foreach (var account in _accounts)
			{
				_report = new Report { AccountName = account.Name, Dt = new List<ReportDocument>(), Ct = new List<ReportDocument>() };

				GetAccountOpeningsDictionaryForAccount(account);
				GetAccountDocumentsForAccountSide(account, report => report.Dt, openings => openings.Dt, document=>document.AccountDt);
				GetAccountDocumentsForAccountSide(account, report => report.Ct, openings => openings.Ct, document=>document.AccountCt);
				CalculateSums();
				CalculateClosingForSideCt();
				CalculateClosingForSideDt();

				if (AnyDocumentsExists())
					_result.Add(_report);
			}

			return _result;
		}

		private void CalculateSums()
		{
			_report.CtSum = _report.Ct.Sum(x => x.Price);
			_report.DtSum = _report.Dt.Sum(x => x.Price);
		}

		private void CalculateClosingForSideCt()
		{
			_report.CtClosing = _report.Ct.Sum(x => x.Price) - _report.Dt.Sum(x => x.Price);
			if (_report.CtClosing < 0) _report.CtClosing = 0;
		}

		private void CalculateClosingForSideDt()
		{
			_report.DtClosing = _report.Dt.Sum(x => x.Price) - _report.Ct.Sum(x => x.Price);
			if (_report.DtClosing < 0) _report.DtClosing = 0;
		}

		private bool AnyDocumentsExists()
		{
			return IsNotZero(_report.Ct.Sum(c => c.Price)) || IsNotZero(_report.Dt.Sum(c=>c.Price));
		}

		private static bool IsNotZero(double value)
		{
			return Math.Abs(value) > 0.0009;
		}

		private void GetAccountDocumentsForAccountSide(AccountDao account, Func<Report, IList<ReportDocument>> reportLambda, Func<OpeningDao, double> openingsFunction, Func<DocumentDao, string> documentProperty )
		{
			foreach (var opening in _openings)
				reportLambda.Invoke(_report).Add(new ReportDocument { Id = opening.Id, AutoNumber = "BO", Number = "BO", Price = openingsFunction.Invoke(opening) });

			var allDocuments = _dbContext.Documents.Where(c => c.ClientId.Equals(_clientId) && c.Year.Equals(_year)).ToList();
			_documents = allDocuments.Where(c => documentProperty.Invoke(c).Equals(account.Name)).OrderBy(x => x.AutoNumber).ToList();
			foreach (var item in _documents)
				reportLambda.Invoke(_report).Add(new ReportDocument { Id = item.Id, AutoNumber = item.AutoNumber.ToString(), Number = item.Number, Price = item.Price });
		}

		private void GetAccountOpeningsDictionaryForAccount(AccountDao account)
		{
			_openings = _dbContext.Openings.Where(c => c.ClientId.Equals(_clientId) && c.Year.Equals(_year) && c.Name.Equals(account.Name)).ToList();
		}

		private void GetAccounts()
		{
			_accounts = _dbContext.Accounts.Where(c => c.ClientId.Equals(_clientId) && c.Year.Equals(_year)).OrderBy(c => c.Name).ToList();
		}

		private void PrepareReport()
		{
			_result = new List<Report>();
		}
	}
}
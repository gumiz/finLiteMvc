using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Repository.Abstract;
using Repository.DAL;
using Repository.Domain;

namespace Repository.Services
{
	public class ProfitLossService : IProfitLossService
	{
		private readonly DefaultContext _dbContext;
		private List<DocumentDao> _documents;
		private IList<ProfitAndLossReportItem> _formulas;
		private List<ProfitAndLossReportValues> _result;
		private List<DocumentDao> _documentsOld;

		public ProfitLossService(DefaultContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<ProfitAndLossReportItem> GetItems()
		{
			var itemsDao = _dbContext.ProfitLossReport.OrderBy(c=>c.Id).ToList();
			var items = Converter.ConvertList<ProfitAndLossReportItemDao, ProfitAndLossReportItem>(itemsDao);
			return items;
		}

		public IList<ProfitAndLossReportValues> GetValues(int clientId, int year)
		{
			_result = new List<ProfitAndLossReportValues>();
			_documents = _dbContext.Documents.Where(c => c.ClientId.Equals(clientId) && c.Year.Equals(year)).ToList();
			_documentsOld = _dbContext.Documents.Where(c => c.ClientId.Equals(clientId) && c.Year.Equals(year-1)).ToList();
			_formulas = GetItems();
			foreach (var formula in _formulas)
			{
				var accounts = UndressFormula(formula.Formula);
				double sum = 0;
				double sumOld = 0;
				foreach (var decAcc in accounts)
				{
					if (decAcc.Side == null) continue;
					sum += _documents.Where(c => decAcc.Side.Invoke(c).StartsWith(decAcc.Name)).Sum(c => c.Price) * decAcc.Multiplier;
					sumOld += _documentsOld.Where(c => decAcc.Side.Invoke(c).StartsWith(decAcc.Name)).Sum(c => c.Price) * decAcc.Multiplier;
			}
				_result.Add(new ProfitAndLossReportValues {Id = formula.Id, Number = formula.Number, Description = formula.Description, Balance1 = sumOld, Balance2 = sum});
			}
			return _result;
		}

		private IList<DecodedAccount> UndressFormula(string formula)
		{
			var result = new List<DecodedAccount>();
			formula = formula.Replace(" ", "");
			var items = formula.ToUpper().Split(',');
			foreach (var item in items)
			{
				var accFormula = item;
				Func<DocumentDao, string> side = null;
				var acc = accFormula;
				var multiplier = 1;
				if (accFormula.Contains("WN") || accFormula.Contains("MA"))
				{
					if (accFormula.StartsWith("-"))
					{
						accFormula = accFormula.Substring(1, accFormula.Length - 1);
						multiplier = -1;
					}
					acc = accFormula.Substring(0, accFormula.Length - 2);
					var s = accFormula.Substring(accFormula.Length - 2, 2);
					if (s.Equals("WN"))
						side = x => x.AccountDt;
					else
						side = x => x.AccountCt;
				}
				result.Add(new DecodedAccount {Name = acc, Side = side, Multiplier = multiplier});
			}
			return result;
		}
	}

	public class DecodedAccount
	{
		public DecodedAccount()
		{
			Multiplier = 1;
		}
		public string Name { get; set; }
		public Func<DocumentDao, string> Side { get; set; }
		public int Multiplier { get; set; }
	}
}
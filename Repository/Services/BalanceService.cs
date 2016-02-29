using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Repository.Abstract;
using Repository.DAL;
using Repository.Domain;

namespace Repository.Services
{
	public class BalanceService : IBalanceService
	{
		private readonly DefaultContext _dbContext;
		private List<DocumentDao> _documents;
		private IList<BalanceReportItem> _formulas;
		private List<BalanceReportValues> _result;
		private List<DocumentDao> _documentsOld;
		private int _clientId;
		private int _year;
		private readonly IFactory _factory;

		public BalanceService(IFactory factory)
		{
			_factory = factory;
			_dbContext = _factory.GetDbContext();
		}

		public IList<BalanceReportItem> GetAllItems(int clientId)
		{
			var itemsDao = _dbContext.BalanceReport.Where(c => c.ClientId.Equals(clientId)).OrderBy(c => c.RowId).ToList();
			var items = Converter.ConvertList<BalanceReportItemDao, BalanceReportItem>(itemsDao);
			return items;
		}

		public BalanceItems GetItems(int clientId)
		{
			var itemsDao = _dbContext.BalanceReport.Where(c => c.ClientId.Equals(clientId)).OrderBy(c => c.RowId).ToList();
			var items = Converter.ConvertList<BalanceReportItemDao, BalanceReportItem>(itemsDao);
			var result = new BalanceItems
			{
				Actives = items.Where(c => c.Type.ToUpper().Equals("AKTYWA")).ToList(),
				Passives = items.Where(c => c.Type.ToUpper().Equals("PASYWA")).ToList()
			};
			return result;
		}

		public void SaveItems(int clientId, BalanceItems items)
		{
			var flatenedItems = new List<BalanceReportItem>();
			flatenedItems.AddRange(items.Actives);
			flatenedItems.AddRange(items.Passives);
			var result = _dbContext.BalanceReport.Where(c => c.ClientId.Equals(clientId)).ToList();
			foreach (var row in result)
			{
				var newItem = flatenedItems.FirstOrDefault(c => c.Id.Equals(row.Id));
				if (newItem != null)
					row.Formula = newItem.Formula;
				_dbContext.BalanceReport.AddOrUpdate(row);
			}
			_dbContext.SaveChanges();
		}

		public IList<BalanceReportValues> GetValues(int clientId, int year)
		{
			_clientId = clientId;
			_year = year;
			GetRowsWithValues();
			SortRows();
			CalculateSummaries();
			return _result;
		}

		private void GetRowsWithValues()
		{
			_result = new List<BalanceReportValues>();

			_documents = _dbContext.Documents.Where(c => c.ClientId.Equals(_clientId) && c.Year.Equals(_year)).ToList();
			AddOpeningsToDocuments(_documents, _year);

			_documentsOld = _dbContext.Documents.Where(c => c.ClientId.Equals(_clientId) && c.Year.Equals(_year - 1)).ToList();
			AddOpeningsToDocuments(_documentsOld, _year - 1);

			_formulas = GetAllItems(_clientId);
			foreach (var formula in _formulas)
			{
				double sum = 0;
				double sumOld = 0;
				if (formula.Formula != null)
				{
					var accounts = UndressFormula(formula.Formula);
					foreach (var decAcc in accounts)
					{
						if (decAcc.Side == null) continue;
						sum += _documents.Where(c => decAcc.Side.Invoke(c).StartsWith(decAcc.Name)).Sum(c => c.Price) * decAcc.Multiplier;
						sumOld += _documentsOld.Where(c => decAcc.Side.Invoke(c).StartsWith(decAcc.Name)).Sum(c => c.Price) *
						          decAcc.Multiplier;
					}
				}
				_result.Add(new BalanceReportValues
				{
					RowId = formula.RowId,
					IsBold = formula.IsBold,
					Number = formula.Number,
					Type = formula.Type,
					Description = formula.Description,
					Balance1 = sumOld,
					Balance2 = sum
				});
			}
		}

		private void AddOpeningsToDocuments(List<DocumentDao> documents, int year)
		{
			var openingsWithoutDoubles = _factory.GetOpeningsService().GetOpeningsWithoutDoubles(_clientId, year);
			foreach (var opening in openingsWithoutDoubles)
			{
				documents.Add(new DocumentDao {AccountDt = opening.Name, AccountCt = "", Price = opening.Dt});
				documents.Add(new DocumentDao {AccountCt = opening.Name, AccountDt = "", Price = opening.Ct});
			}
		}

		private void SortRows()
		{
			_result = _result.OrderBy(c=>c.Type).ThenBy(x=>x.RowId).ToList();
		}

		private void CalculateSummaries()
		{
			CalculateActives();
			CalculatePassives();
		}

		private void CalculateActives()
		{
			_result[0].Balance1 = _result[1].Balance1 + _result[2].Balance1 + _result[3].Balance1 + _result[4].Balance1 + _result[5].Balance1;
			_result[6].Balance1 = _result[7].Balance1 + _result[8].Balance1 + _result[10].Balance1 + _result[11].Balance1;
			_result[9].Balance1 = _result[10].Balance1 + _result[11].Balance1;
			_result[13].Balance1 = _result[0].Balance1 + _result[6].Balance1 + _result[12].Balance1;

			_result[0].Balance2 = _result[1].Balance2 + _result[2].Balance2 + _result[3].Balance2 + _result[4].Balance2 + _result[5].Balance2;
			_result[6].Balance2 = _result[7].Balance2 + _result[8].Balance2 + _result[10].Balance2 + _result[11].Balance2;
			_result[9].Balance2 = _result[10].Balance2 + _result[11].Balance2;
			_result[13].Balance2 = _result[0].Balance2 + _result[6].Balance2 + _result[12].Balance2;
		}

		private void CalculatePassives()
		{
			_result[14].Balance1 = _result[15].Balance1 + _result[16].Balance1 + _result[18].Balance1 + _result[19].Balance1;
			_result[17].Balance1 = _result[18].Balance1 + _result[19].Balance1;
			_result[20].Balance1 = _result[21].Balance1 + _result[23].Balance1 + _result[24].Balance1 + _result[25].Balance1 + _result[26].Balance1 + _result[28].Balance1 + _result[29].Balance1;
			_result[22].Balance1 = _result[23].Balance1 + _result[24].Balance1 + _result[25].Balance1;
			_result[27].Balance1 = _result[28].Balance1 + _result[29].Balance1;
			_result[30].Balance1 = _result[14].Balance1 + _result[20].Balance1;

			_result[14].Balance2 = _result[15].Balance2 + _result[16].Balance2 + _result[18].Balance2 + _result[19].Balance2;
			_result[17].Balance2 = _result[18].Balance2 + _result[19].Balance2;
			_result[20].Balance2 = _result[21].Balance2 + _result[23].Balance2 + _result[24].Balance2 + _result[25].Balance2 + _result[26].Balance2 + _result[28].Balance2 + _result[29].Balance2;
			_result[22].Balance2 = _result[23].Balance2 + _result[24].Balance2 + _result[25].Balance2;
			_result[27].Balance2 = _result[28].Balance2 + _result[29].Balance2;
			_result[30].Balance2 = _result[14].Balance2 + _result[20].Balance2;
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
				result.Add(new DecodedAccount { Name = acc, Side = side, Multiplier = multiplier });
			}
			return result;
		}
	}
}
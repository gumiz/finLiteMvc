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
		private IList<BalanceReportItem> _items;

		public BalanceService(DefaultContext dbContext)
		{
			_dbContext = dbContext;
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

		public void SaveItems(int clientId, IList<BalanceReportItem> items)
		{
			var result = _dbContext.BalanceReport.Where(c => c.ClientId.Equals(clientId)).ToList();
			foreach (var row in result)
			{
				var newItem = items.FirstOrDefault(c => c.Id.Equals(row.Id));
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
			_documentsOld = _dbContext.Documents.Where(c => c.ClientId.Equals(_clientId) && c.Year.Equals(_year - 1)).ToList();
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
					Description = formula.Description,
					Balance1 = sumOld,
					Balance2 = sum
				});
			}
		}

		private void SortRows()
		{
			_result = _result.OrderBy(c => c.RowId).ToList();
		}
		private void CalculateSummaries()
		{
			_result[0].Balance1 = _result[1].Balance1 + _result[2].Balance1;
			_result[4].Balance1 = _result[0].Balance1 - _result[3].Balance1;
			_result[5].Balance1 = _result[6].Balance1 + _result[7].Balance1 + _result[8].Balance1 + _result[9].Balance1 + _result[10].Balance1 + _result[11].Balance1;
			_result[16].Balance1 = _result[4].Balance1 - _result[5].Balance1 + _result[12].Balance1 - _result[13].Balance1 + _result[14].Balance1 - _result[15].Balance1;
			_result[18].Balance1 = _result[16].Balance1 + _result[17].Balance1;
			_result[19].Balance1 = _result[18].Balance1 < 0 ? -_result[18].Balance1 : 0;
			_result[20].Balance1 = _result[18].Balance1 >= 0 ? _result[18].Balance1 : 0;

			_result[0].Balance2 = _result[1].Balance2 + _result[2].Balance2;
			_result[4].Balance2 = _result[0].Balance2 - _result[3].Balance2;
			_result[5].Balance2 = _result[6].Balance2 + _result[7].Balance2 + _result[8].Balance2 + _result[9].Balance2 + _result[10].Balance2 + _result[11].Balance2;
			_result[16].Balance2 = _result[4].Balance2 - _result[5].Balance2 + _result[12].Balance2 - _result[13].Balance2 + _result[14].Balance2 - _result[15].Balance2;
			_result[18].Balance2 = _result[16].Balance2 + _result[17].Balance2;
			_result[19].Balance2 = _result[18].Balance2 < 0 ? -_result[18].Balance2 : 0;
			_result[20].Balance2 = _result[18].Balance2 >= 0 ? _result[18].Balance2 : 0;

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
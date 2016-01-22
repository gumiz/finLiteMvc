using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Abstract;
using Repository.DAL;
using Repository.Domain;

namespace Repository.Services
{
	public class OpeningsService : IOpeningsService
	{
		private readonly DefaultContext _dbContext;
		private List<Opening> _openings;
		private int _clientId;
		private int _year;
		private List<Account> _accounts;

		public OpeningsService(DefaultContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<Opening> GetOpenings(int clientId, int year)
		{
			_clientId = clientId;
			_year = year;
			GetAccounts();
			GetOpenings();
			AddNonExistantAccounts();
			return _openings.OrderBy(x=>x.Name).ToList();
		}
		public void SaveOpenings(List<Opening> openings)
		{
			_openings = openings;
			if (_openings.Count == 0) return;
			RemoveOldOpenings();
			AddNewOpenings();
		}

		private void AddNonExistantAccounts()
		{
			foreach (var account in _accounts)
				if (!_openings.Exists(x => x.Name.Equals(account.Name))) 
					_openings.Add(new Opening {ClientId = _clientId, Year = _year, Name = account.Name, Description = account.Description, Ct = 0, Dt = 0});
		}

		private void GetAccounts()
		{
			var accountsDao = _dbContext.Accounts.Where(c => c.ClientId.Equals(_clientId) && c.Year.Equals(_year)).ToList();
			_accounts = Converter.ConvertList<AccountDao, Account>(accountsDao);
		}

		private void GetOpenings()
		{
			var openingsDao = _dbContext.Openings.Where(x => x.ClientId.Equals(_clientId) && x.Year.Equals(_year)).ToList();
			_openings = Converter.ConvertList<OpeningDao, Opening>(openingsDao);
		}

		private void AddNewOpenings()
		{
			var openingsDao = Converter.ConvertList<Opening, OpeningDao>(_openings);
			_dbContext.Openings.AddRange(openingsDao);
			_dbContext.SaveChanges();
		}

		private void RemoveOldOpenings()
		{
			var year = _openings[0].Year;
			var clientId = _openings[0].ClientId;
			var oldOpenings = _dbContext.Openings.Where(c => c.ClientId.Equals(clientId) && c.Year.Equals(year));
			_dbContext.Openings.RemoveRange(oldOpenings);
		}
	}
}
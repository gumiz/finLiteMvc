using System.Collections.Generic;
using System.Linq;
using Repository.Abstract;
using Repository.DAL;
using Repository.Domain;

namespace Repository.Services
{
	public class AccountsService : IAccountsService
	{
		private readonly DefaultContext dbContext;

		public AccountsService(DefaultContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IList<Account> GetAccounts()
		{
			var accountsDao = dbContext.AccountDao.ToList();
			var accounts = Converter.ConvertList<AccountDao, Account>(accountsDao);
			return accounts;
		}

		public void AddAccount(Account account)
		{
			var accountDao = Converter.Convert<Account, AccountDao>(account);
			dbContext.AccountDao.Add(accountDao);
			dbContext.SaveChanges();
		}

		public void DeleteAccount(string name)
		{
			var accountDao = dbContext.AccountDao.FirstOrDefault(x => x.Name.Equals(name));
			dbContext.AccountDao.Remove(accountDao);
			dbContext.SaveChanges();
		}
	}
}
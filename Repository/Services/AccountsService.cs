using System.Collections.Generic;
using Repository.Abstract;
using Repository.Domain;

namespace Repository.Services
{
	public class AccountsService : IAccountsService
	{
		public IList<Account> GetAccounts()
		{
			var accounts = new List<Account>();
			accounts.Add(new Account {Name = "001", Description = "Test1"});
			accounts.Add(new Account {Name = "002", Description = "Test2"});
			return accounts;
		}
	}
}
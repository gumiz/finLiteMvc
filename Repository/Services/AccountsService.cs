﻿using System.Collections.Generic;
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

		public IList<Account> GetAccounts(int clientId)
		{
			var accountsDao = dbContext.Accounts.Where(x=>x.ClientId.Equals(clientId)).ToList();
			var accounts = Converter.ConvertList<AccountDao, Account>(accountsDao);
			return accounts;
		}

		public void AddAccount(Account account)
		{
			var accountDao = Converter.Convert<Account, AccountDao>(account);
			dbContext.Accounts.Add(accountDao);
			dbContext.SaveChanges();
		}

		public void DeleteAccount(Account account)
		{
			var accountDao = dbContext.Accounts.Where(x => x.ClientId.Equals(account.ClientId)).FirstOrDefault(x => x.Name.Equals(account.Name));
			dbContext.Accounts.Remove(accountDao);
			dbContext.SaveChanges();
		}
	}
}
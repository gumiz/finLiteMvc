using System.Collections.Generic;
using Repository.Domain;

namespace Repository.Abstract
{
	public interface IAccountsService
	{
		IList<Account> GetAccounts();
		void AddAccount(Account account);
		void DeleteAccount(string name);
	}
}
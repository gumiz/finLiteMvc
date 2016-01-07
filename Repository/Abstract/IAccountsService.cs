using System.Collections.Generic;
using Repository.Domain;

namespace Repository.Abstract
{
	public interface IAccountsService
	{
		IList<Account> GetAccounts(int clientId);
		void AddAccount(Account account);
		void DeleteAccount(Account account);
	}
}
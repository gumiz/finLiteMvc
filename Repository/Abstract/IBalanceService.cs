using System.Collections.Generic;
using Repository.Domain;

namespace Repository.Abstract
{
	public interface IBalanceService
	{
		void SaveItems(int clientId, IList<BalanceReportItem> items);
		BalanceItems GetItems(int clientId);
        IList<BalanceReportItem> GetAllItems(int clientId);
		IList<BalanceReportValues> GetValues(int clientId, int year);
	}
}
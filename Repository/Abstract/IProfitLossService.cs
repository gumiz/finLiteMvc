using System.Collections.Generic;
using Repository.Domain;

namespace Repository.Abstract
{
	public interface IProfitLossService
	{
		IList<ProfitAndLossReportItem> GetItems(int clientId);
		void SaveItems(int clientId, IList<ProfitAndLossReportItem> items);
		IList<ProfitAndLossReportValues> GetValues(int clientId, int year);
	}
}
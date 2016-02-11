using System.Collections.Generic;
using Repository.Domain;

namespace Repository.Abstract
{
	public interface IProfitLossService
	{
		void SaveItems(int clientId, IList<ProfitAndLossReportItem> items);
		IList<ProfitAndLossReportItem> GetItems(int clientId);
		IList<ProfitAndLossReportValues> GetValues(int clientId, int year);
	}
}
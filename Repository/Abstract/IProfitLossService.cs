using System.Collections.Generic;
using Repository.Domain;

namespace Repository.Abstract
{
	public interface IProfitLossService
	{
		IList<ProfitAndLossReportItem> GetItems();
		IList<ProfitAndLossReportValues> GetValues(int clientId, int year);
	}
}
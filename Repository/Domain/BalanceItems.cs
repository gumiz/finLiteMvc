using System.Collections.Generic;

namespace Repository.Domain
{
	public class BalanceItems
	{
		public IList<BalanceReportItem> Actives { get; set; }
		public IList<BalanceReportItem> Passives { get; set; }
	}
}
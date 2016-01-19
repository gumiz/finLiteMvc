using System.Collections.Generic;

namespace Repository.Domain
{
	public class Report
	{
		public string AccountName { get; set; }
		public IList<ReportDocument> Dt { get; set; }
		public IList<ReportDocument> Ct { get; set; }
	}
}
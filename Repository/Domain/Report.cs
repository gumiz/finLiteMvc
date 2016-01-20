using System.Collections.Generic;

namespace Repository.Domain
{
	public class Report
	{
		public string AccountName { get; set; }

		public IList<ReportDocument> Dt { get; set; }
		public IList<ReportDocument> Ct { get; set; }

		public double DtSum { get; set; }
		public double CtSum { get; set; }

		public double DtClosing { get; set; }
		public double CtClosing { get; set; }
	}
}
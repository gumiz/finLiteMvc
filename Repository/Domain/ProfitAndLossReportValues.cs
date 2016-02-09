namespace Repository.Domain
{
	public class ProfitAndLossReportValues
	{
		public int RowId { get; set; }

		public string Number { get; set; }

		public string Description { get; set; }

		public double Balance1 { get; set; }
		public double Balance2 { get; set; }
		public bool IsBold { get; set; }
	}
}
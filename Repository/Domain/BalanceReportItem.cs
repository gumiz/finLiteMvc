namespace Repository.Domain
{
	public class BalanceReportItem
	{
		public int Id { get; set; }

		public int ClientId { get; set; }

		public int RowId { get; set; }

		public string Type { get; set; }

		public string Number { get; set; }

		public string Description { get; set; }

		public string Formula { get; set; }

		public bool IsReadOnly { get; set; }

		public bool IsBold { get; set; }
	}
}
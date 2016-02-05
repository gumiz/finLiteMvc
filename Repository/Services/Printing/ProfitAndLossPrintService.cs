namespace Repository.Services.Printing
{
	public class ProfitAndLossPrintService : AbstractPrintService
	{
		public ProfitAndLossPrintService(Factory factory) : base(factory)
		{
		}

		protected override void GetRows()
		{
			Rows = "";
			var items = Factory.GetProfitLossService().GetItems();
			foreach (var ac in items)
				Rows += $"<tr><td class=\"col-1\">{ac.Number}</td><td class=\"col-8\">{ac.Description}</td></td><td class=\"col-3 right\">{ac.Formula}</td></tr>";
		}

		protected override void GetHeaderRow()
		{
			HeaderRow = "<tr><th class=\"col-1\"></th><th class=\"col-8\">Opis</th><th class=\"col-3 right\">Stan</th></tr>";
		}

		protected override void GetTitle()
		{
			Title = $"Rachunek wyników za rok {Year}";
		}

		protected override void GetTableClass()
		{
			TableClass = "col-10";
		}

	}
}
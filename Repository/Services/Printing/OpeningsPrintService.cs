namespace Repository.Services.Printing
{
	public class OpeningsPrintService : AbstractPrintService
	{
		public OpeningsPrintService(Factory factory) : base(factory)
		{
		}

		protected override void GetRows()
		{
			Rows = "";
			var openings = Factory.GetOpeningsService().GetOpenings(ClientdId, Year);
			foreach (var ac in openings)
			{
				var dt = DecimalToString(ac.Dt);
				var ct = DecimalToString(ac.Ct);
                Rows += $"<tr><td class=\"col-2\">{ac.Name}</td><td class=\"col-6\">{ac.Description}</td><td class=\"col-2 right\">{dt}</td><td class=\"col-2 right\">{ct}</td></tr>";
			}
		}

		protected override void GetHeaderRow()
		{
			HeaderRow = "<tr><th class=\"col-2\">Numer</th><th class=\"col-6\">Nazwa</th><th class=\"col-2 right\">BO WN</th><th class=\"col-2 right\">BO MA</th></tr>";
		}

		protected override void GetTitle()
		{
			Title = $"Bilans otwarcia na rok {Year}";
		}

		protected override void GetTableClass()
		{
			TableClass = "col-10";
		}
	}
}
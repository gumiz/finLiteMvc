using Repository.Domain;

namespace Repository.Services.Printing
{
	public class OpeningsPrintService : AbstractPrintService
	{
		private double _sumDt;
		private double _sumCt;

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
				AddSums(ac);
                Rows += $"<tr><td class=\"col-2\">{ac.Name}</td><td class=\"col-6\">{ac.Description}</td><td class=\"col-2 right\">{dt}</td><td class=\"col-2 right\">{ct}</td></tr>";
			}
			Rows += $"<tr><td class=\"col-2\"></td><td class=\"right col-6\">suma syntetyk:</td><td class=\"col-2 right bold\">"+ DecimalToString(_sumDt) + "</td><td class=\"col-2 right bold\">" + DecimalToString(_sumCt) + "</td></tr>";
		}

		private void AddSums(Opening ac)
		{
			if (ac.Name.Length == 3)
			{
				_sumDt += ac.Dt;
				_sumCt += ac.Ct;
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
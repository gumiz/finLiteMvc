using System;
using System.Linq;

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
			var items = Factory.GetProfitLossService().GetValues(ClientdId, Year);
			foreach (var ac in items)
			{
				var bold = ac.IsBold ? "bold" : "";
				Rows += $"<tr class=\"{bold}\"><td class=\"col-1\">{ac.Number}</td><td class=\"col-5\">{ac.Description}</td><td class=\"col-3 right\">{DecimalToString(ac.Balance1)}</td><td class=\"col-3 right\">{DecimalToString(ac.Balance2)}</td></tr>";
            }
		}

		protected override void GetHeaderRow()
		{
			HeaderRow = $"<tr><th class=\"col-1\"></th><th class=\"col-5\">Treść</th><th class=\"col-3 right\">Kwota [w zł]<br/>Stan na {EndOfPrevYear}</th><th class=\"col-3 right\">Kwota [w zł]<br/>Stan na {EndOfThisYear}</th></tr>";
		}

		protected override void GetTitle()
		{
			var startOfThisYear =  DateToString(new DateTime(Year, 1, 1));
			Title = $"Rachunek wyników za rok {Year} tj. za okres od {startOfThisYear} do {EndOfThisYear}";
		}

		protected override void GetTableClass()
		{
			TableClass = "col-12";
		}

		protected override void GetUser()
		{
			User = "";
			var client = Factory.GetClientsService().GetClients().FirstOrDefault(x => x.ClientId.Equals(ClientdId));
			if (client == null) return;
			var address = client.Address != "" ? client.Address : "-uzupełnij adres klienta-";
			User = client.Description + "<br/>" + address + "<br/><br/>";
		}

	}
}
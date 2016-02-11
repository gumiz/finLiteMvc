using System;
using System.Linq;

namespace Repository.Services.Printing
{
	public class BalancePrintService : AbstractPrintService
	{
		public BalancePrintService(Factory factory) : base(factory)
		{
		}

		protected override void GetRows()
		{
			Rows = "";
			var items = Factory.GetBalanceService().GetValues(ClientdId, Year);
			foreach (var ac in items)
			{
				var bold = ac.IsBold ? "bold" : "";
				Rows += $"<tr class=\"{bold}\"><td class=\"col-1\">{ac.Number}</td><td class=\"col-5\">{ac.Description}</td></td><td class=\"col-3 right\">{DecimalToString(ac.Balance1)}</td><td class=\"col-3 right\">{DecimalToString(ac.Balance2)}</td></tr>";
			}
		}

		protected override void GetHeaderRow()
		{
			var from = DateToString(new DateTime(Year - 1, 12, 31));
			var to = DateToString(new DateTime(Year, 12, 31));
			HeaderRow = $"<tr><th class=\"col-1\"></th><th class=\"col-5\">Tre��</th><th class=\"col-3 right\">Kwota [w z�]<br/>Stan na {from}</th><th class=\"col-3 right\">Kwota [w z�]<br/>Stan na {to}</th></tr>";
		}

		protected override void GetTitle()
		{
			var from = DateToString(new DateTime(Year, 1, 1));
			var to = DateToString(new DateTime(Year, 12, 31));
			Title = $"Rachunek wynik�w za rok {Year} tj. za okres od {from} do {to}";
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
			var address = client.Address != "" ? client.Address : "-uzupe�nij adres klienta-";
			User = client.Description + "<br/><br/>" + address;
		}

	}
}
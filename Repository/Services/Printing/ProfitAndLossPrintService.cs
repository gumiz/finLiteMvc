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
				Rows += $"<tr class=\"{bold}\"><td class=\"col-1\">{ac.Number}</td><td class=\"col-7\">{ac.Description}</td></td><td class=\"col-2 right\">{DecimalToString(ac.Balance1)}</td><td class=\"col-2 right\">{DecimalToString(ac.Balance2)}</td></tr>";
            }
		}

		protected override void GetHeaderRow()
		{
			HeaderRow = $"<tr><th class=\"col-1\"></th><th class=\"col-7\">Treść</th><th class=\"col-2 right\">Stan koniec {Year-1}</th><th class=\"col-2 right\">Stan koniec {Year}</th></tr>";
		}

		protected override void GetTitle()
		{
			Title = $"Rachunek wyników za rok {Year}";
		}

		protected override void GetTableClass()
		{
			TableClass = "col-10";
		}

		protected override void GetUser()
		{
			var client = Factory.GetClientsService().GetClients().FirstOrDefault(x => x.ClientId.Equals(ClientdId));
			User = client != null ? client.Description + "<br/><br/>" + client.Description : "";
		}

	}
}
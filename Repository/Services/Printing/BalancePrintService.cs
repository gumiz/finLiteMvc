using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Domain;

namespace Repository.Services.Printing
{
	public class BalancePrintService : AbstractPrintService
	{
		private IList<BalanceReportValues> _items;

		public BalancePrintService(Factory factory) : base(factory)
		{
		}

		protected override void GetHeaderRow()
		{
			HeaderRow = $"<tr><th colspan=\"4\" class=\"center bold fixedColor\">AKTYWA</th></tr>";
			HeaderRow += $"<tr><th class=\"col-1\"></th><th class=\"col-5\">Treœæ</th><th class=\"col-3 right\">Kwota [w z³]<br/>Stan na {EndOfPrevYear}</th><th class=\"col-3 right\">Kwota [w z³]<br/>Stan na {EndOfThisYear}</th></tr>";
		}

		protected override void GetRows()
		{
			Rows = "";
			_items = Factory.GetBalanceService().GetValues(ClientdId, Year);
			GetRowsOfSelectedType("AKTYWA");
			Rows += $"<tr><th colspan=\"4\" class=\"center bold fixedColor\">PASYWA</th></tr>";
			Rows += $"<tr><th class=\"col-1\"></th><th class=\"col-5\">Treœæ</th><th class=\"col-3 right\">Kwota [w z³]<br/>Stan na {EndOfPrevYear}</th><th class=\"col-3 right\">Kwota [w z³]<br/>Stan na {EndOfThisYear}</th></tr>";
			GetRowsOfSelectedType("PASYWA");
		}

		private void GetRowsOfSelectedType(string type)
		{
			var typeItems = _items.Where(c => c.Type.Equals(type)).ToList();
			foreach (var ac in typeItems)
			{
				var bold = ac.IsBold ? "bold" : "";
				Rows += $"<tr class=\"{bold}\"><td class=\"col-1\">{ac.Number}</td><td class=\"col-5\">{ac.Description}</td><td class=\"col-3 right\">{DecimalToString(ac.Balance1)}</td><td class=\"col-3 right\">{DecimalToString(ac.Balance2)}</td></tr>";
			}
		}

		protected override void GetTitle()
		{
			var date = DateToString(new DateTime(Year, 12, 31));
			Title = $"Bilans na {date}";
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
			var address = client.Address != "" ? client.Address : "-uzupe³nij adres klienta-";
			User = client.Description + "<br/>" + address + "<br/><br/>";
		}

	}
}
using System;

namespace Repository.Services.Printing
{
	public class DocumentsPrintService : AbstractPrintService
	{
		public DocumentsPrintService(Factory factory) : base(factory)
		{
		}

		protected override void GetRows()
		{
			Rows = "";
			var documents = Factory.GetDocumentsService().GetDocuments(Year, ClientdId);
			foreach (var item in documents)
			{
				var price = DecimalToString(item.Price);
				Rows += String.Format("<tr style=\"font-size: 0.5em\">" +
				                      "<th style=\"width:2%\">{0}</th>" +
									  "<th style=\"width:12%\">{1}</th>" +
									  "<th style=\"width:10%\">{2}</th>" +
									  "<th>{3}</th>" +
									  "<th style=\"width:12%\" class=\"right\">{4}</th>" +
									  "<th style=\"width:12%\" class=\"right\">{5}</th>" +
									  "<th style=\"width:12%\" class=\"right bold\">{6}</th>" +
				                      "</tr>", item.AutoNumber, DateToString(item.Date), item.Number, item.Description, item.AccountDt, item.AccountCt, DecimalToString(item.Price));
			}
		}

		protected override void GetHeaderRow()
		{
			HeaderRow = "<tr>" +
						"<th style=\"width:2%\">Lp</th>" +
						"<th style=\"width:12%\">Data</th>" +
						"<th style=\"width:10%\">Numer</th>" +
						"<th>Opis</th>" +
						"<th style=\"width:12%\" class=\"right\">Wn</th>" +
						"<th style=\"width:12%\" class=\"right\">Ma</th>" +
						"<th style=\"width:12%\" class=\"right\">Kwota</th>" +
			            "</tr>";
		}

		protected override void GetTitle()
		{
			Title = $"Dokumenty roku {Year}";
		}

		protected override void GetTableClass()
		{
			TableClass = "col-12";
		}
    }
}
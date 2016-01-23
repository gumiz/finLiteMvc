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
				Rows += String.Format("<tr style=\"font-size: 0.6em\">" +
				                      "<th class=\"col-1\">{0}</th>" +
									  "<th class=\"col-1\" style=\"font-size: 0.6em\">{1}</th>" +
				                      "<th class=\"col-2\">{2}</th>" +
				                      "<th class=\"col-4\">{3}</th>" +
									  "<th class=\"col-1 right\" style=\"font-size: 0.6em\">{4}</th>" +
									  "<th class=\"col-1 right\" style=\"font-size: 0.6em\">{5}</th>" +
				                      "<th class=\"col-2 right bold\">{6}</th>" +
				                      "</tr>", item.AutoNumber, DateToString(item.Date), item.Number, item.Description, item.AccountDt, item.AccountCt, DecimalToString(item.Price));
			}
		}

		protected override void GetHeaderRow()
		{
			HeaderRow = "<tr>" +
			            "<th class=\"col-1\">Lp</th>" +
			            "<th class=\"col-1\">Data</th>" +
						"<th class=\"col-2\">Numer</th>" +
						"<th class=\"col-4\">Opis</th>" +
						"<th class=\"col-1 right\">Wn</th>" +
						"<th class=\"col-1 right\">Ma</th>" +
			            "<th class=\"col-2 right\">Kwota</th>" +
			            "</tr>";
		}

		protected override void GetTitle()
		{
			Title = $"Dokumenty roku {Year}";
		}

		protected override void GetTableClass()
		{
			TableClass = "col-12 fontXs";
		}
    }
}
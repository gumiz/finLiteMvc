using System;
using System.Linq;
using Repository.Abstract;

namespace Repository.Services.Printing
{
	public abstract class AbstractPrintService : IPrintService
	{
		protected readonly Factory Factory;
		protected string Html;
		protected string User;
		protected int ClientdId;
		protected int Year;
		protected string Title;
		protected string TableClass;
		protected string HeaderRow;
		protected string Rows;

		protected AbstractPrintService(Factory factory)
		{
			Factory = factory;
		}

		public virtual string GetHtml()
		{
			return Html;
		}

		public string GetPdf(int clientId, int year)
		{
			ClientdId = clientId;
			Year = year;
			EndOfPrevYear = DateToString(new DateTime(Year - 1, 12, 31));
			EndOfThisYear = DateToString(new DateTime(Year, 12, 31));

			GetHtmlBase(ClientdId);
			GetUser();
            GetTitle();
			GetTableClass();
			GetHeaderRow();
			GetRows();
			PopulateHtml();

			return GetPdf(Html);
		}

		protected string EndOfThisYear { get; set; }

		protected string EndOfPrevYear { get; set; }

		protected abstract void GetRows();

		protected abstract void GetHeaderRow();

		protected abstract void GetTitle();

		protected abstract void GetTableClass();

		protected virtual void GetUser()
		{
			var client = Factory.GetClientsService().GetClients().FirstOrDefault(x => x.ClientId.Equals(ClientdId));
			User = client != null ? client.Description : "";
		}

		private void PopulateHtml()
		{
			Html = Html.Replace("{{title}}", Title);
			Html = Html.Replace("{{tableClass}}", TableClass);
			Html = Html.Replace("{{headerRow}}", HeaderRow);
			Html = Html.Replace("{{rows}}", Rows);
			Html = Html.Replace("{{user}}", User);
		}


		protected virtual void GetHtmlBase(int clientId)
		{
			Html = "<html><head><meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\" /><title>FinLite</title>" +
					"<style>.float-clear{clear: both}.float-left{float: left}.float-right{float: right}body{color:#039;}.fontXs{font-size: 0.8em}.bold{font-weight: bold}" +
			       ".right{text-align: right}.center{text-align: center}.col-1{width:8%}.col-2{width:16%}.col-3{width:24%}.col-4{width:32%}.col-5{width:40%}.col-6{width:50%}" +
			       ".col-7{width:58%}.col-8{width:66%}.col-9{width:75%}.col-10{width:83%}.col-11{width:92%}.col-12{width:100%}" +
			       "#one-column-emphasis{font-size:12px;text-align:left;border-collapse:collapse;margin:5px;}" +
			       "#one-column-emphasis th{font-size:12px;font-weight:normal;color:#039;padding:8px 15px;}#one-column-emphasis td{color:#669;border-top:1px solid #e8edff;" +
			       "padding:6px 15px;}.oce-first{background:#d0dafd;border-right:10px solid transparent;border-left:10px solid transparent;}#one-column-emphasis tr:hover td{color:#339;" +
			       "background:#eff2ff;}.title{font-weight:bold; font-size: 1.2em}.title-small{font-size: 1.1em}tbody tr:nth-child(odd){background-color: #dfd7ca;}" +
			       ".fixedColor{background-color: #dfd7ca}</style>" +
			        "</head><body><div>" +
					"<div class=\"float-left col-5 title\">{{title}}</div><div class=\"float-right col-7 right title-small\">{{user}}</div><table class=\"float-clear {{tableClass}} bold\" id=\"one-column-emphasis\">" +
			        "<thead>" +
			        "{{headerRow}}" +
					"</thead><tbody></tbody></table><table class=\"{{tableClass}}\" id=\"one-column-emphasis\"><thead></thead><tbody>" +
			        "{{rows}}" +
			        "</tbody></table><br /></div><hr/ ><p class=\"center\">FinLite ©gumiz 2016</p></body></html>";
		}

		private string GetPdf(string html)
		{
			var htmlContent = html;
			var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
			var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
			var base64EncodedPdf = System.Convert.ToBase64String(pdfBytes);

			return base64EncodedPdf;
		}

		protected string DecimalToString(double value)
		{
			return value.ToString("#,##0.00");
		}

		protected string DateToString(DateTime value)
		{
			return value.ToString("yyyy-MM-dd");
		}
	}
}
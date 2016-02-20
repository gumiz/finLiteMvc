using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Abstract;
using Repository.Domain;

namespace Repository.Services.Printing
{
	public class ReportsPrintService : IPrintService
	{
		protected readonly Factory Factory;
		private string _html;
		private string _user;
		protected int ClientdId;
		protected int Year;
		protected string Title;
		private IList<Report> _reports;
		private string _accountsDivs;

		public ReportsPrintService(Factory factory)
		{
			Factory = factory;
		}

		public string GetHtml()
		{
			return _html;
		}

		public string GetPdf(int clientId, int year)
		{
			ClientdId = clientId;
			Year = year;
			GetReports();

			GetHtmlBase(ClientdId);
			GetUser();
			GetTitle();
			GetAccountsDiv();
			PopulateHtml();

			return GetPdf(_html);
		}

		private void GetAccountsDiv()
		{
			_accountsDivs = "";
			foreach (var report in _reports)
			{
				var table = GetAccountTable(report);
				_accountsDivs += "<div class=\"float border col-5\">"+ table + "</div>";
			}
		}

		private void GetReports()
		{
			_reports = Factory.GetReportsService().GetReports(Year, ClientdId);
		}

		private void GetTitle()
		{
			Title = $"Stan kont za rok {Year}";
		}

		private void GetUser()
		{
			var client = Factory.GetClientsService().GetClients().FirstOrDefault(x => x.ClientId.Equals(ClientdId));
			_user = client != null ? client.Description : "";
		}

		private void PopulateHtml()
		{
			_html = _html.Replace("{{title}}", Title);
			_html = _html.Replace("{{user}}", _user);
			_html = _html.Replace("{{accountsDivs}}", _accountsDivs);
		}


		protected virtual void GetHtmlBase(int clientId)
		{
			_html = "<html><head><meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\" /><title>FinLite</title>" +
			        "<style>.float{float: left; margin: 20px;}.main{background-color:#dfd7ca}.border{border: 1px #dfd7ca solid;}body{color:#039;}.fontXs{font-size: 0.8em}.bold{font-weight: bold}.right{text-align: right}.col-1{width:8%}.col-2{width:16%}.col-3{width:24%}.col-4{width:32%}.col-5{width:40%}.col-6{width:50%}.col-7{width:58%}.col-8{width:66%}.col-9{width:75%}.col-10{width:83%}.col-11{width:92%}.col-12{width:100%}#one-column-emphasis{font-size:12px;text-align:left;border-collapse:collapse;margin:10px 20px 10px 20px;}#one-column-emphasis th{font-size:14px;font-weight:normal;color:#039;_padding:12px 15px;}#one-column-emphasis td{color:#669;border-top:1px solid #e8edff;padding:0px 10px;}.oce-first{background:#d0dafd;border-right:10px solid transparent;border-left:10px solid transparent;}#one-column-emphasis tr:hover td{color:#339;background:#eff2ff;}.title{font-weight:bold; font-size: 1.4em}</style>" +
			        "</head><body><div><p class=\"title\"><b>{{title}}</b> - <i>{{user}}</i></p>" +
					"{{accountsDivs}}" +
					"</div></body></html>";
		}

		private string GetAccountTable(Report report)
		{
			var rows = "";
			for (int i = 0; i < Math.Max(report.Ct.Count, report.Dt.Count); i++)
			{
				var dtName = report.Dt.Count > i ? report.Dt[i].AutoNumber : "";
				var dtPrice = report.Dt.Count > i ? DecimalToString(report.Dt[i].Price) : "";
				var ctName = report.Ct.Count > i ? report.Ct[i].AutoNumber : "";
				var ctPrice = report.Ct.Count > i ? DecimalToString(report.Ct[i].Price) : "";
				rows += "<tr><td class=\"col-2\">" + dtName + "</td><td class=\"col-4 right\">" + dtPrice + "</td><td class=\"col-2\">" + ctName + "</td><td class=\"col-4 right\">" + ctPrice + "</td></tr>";
			}
			var dtBzName = IsZero(report.DtClosing) ? "" : "BZ";
			var dtBzPrice = IsZero(report.DtClosing) ? "" : DecimalToString(report.DtClosing);
			var ctBzName = IsZero(report.CtClosing) ? "" : "BZ";
			var ctBzPrice = IsZero(report.CtClosing) ? "" : DecimalToString(report.CtClosing);

			var table = "<table class=\"main col-11\" id=\"one-column-emphasis\"><thead>" +
					"<tr><th colspan=\"4\"><b>Konto: " + report.AccountName + "</b></th></tr>" +
					"<tr><th class=\"col-2\"></th><th class=\"col-4 right\">Ma</th><th class=\"col-2\"></th><th class=\"col-4 right\">Wn</th></tr>" +
					"</thead><tbody></tbody></table>" +
					"<table class=\"col-11\" id=\"one-column-emphasis\"><thead></thead><tbody>" +
					rows + 
			        "</tbody></table>" +
					"<table class=\"main col-11\" id=\"one-column-emphasis\"><thead></thead><tbody>" +
					"<tr class=\"bold\"><td class=\"col-2\">suma:</td><td class=\"col-4 right\">" + DecimalToString(report.DtSum) + "</td><td class=\"col-2\">suma:</td><td class=\"col-4 right\">" + DecimalToString(report.CtSum) + "</td></tr>" +
					"<tr class=\"bold\"><td class=\"col-2\">" + dtBzName + "</td><td class=\"col-4 right\">" + dtBzPrice + "</td><td class=\"col-2\">" + ctBzName + "</td><td class=\"col-4 right\">" + ctBzPrice + "</td></tr></tbody></table>";
            return table;
		}

		private string GetPdf(string html)
		{
			var htmlContent = html;
			var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
			var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
			var base64EncodedPdf = System.Convert.ToBase64String(pdfBytes);

			return base64EncodedPdf;
		}

		private string DecimalToString(double value)
		{
			return value.ToString("#,##0.00");
		}

		private string DateToString(DateTime value)
		{
			return value.ToString("yyyy-MM-dd");
		}

		private bool IsZero(double value)
		{
			return Math.Abs(value) < 0.0009;
		}
	}

}
using Repository.Abstract;

namespace Repository.Services
{
	public class PrintService : IPrintService
	{
		private readonly Factory _factory;

		public PrintService(Factory factory)
		{
			_factory = factory;
		}

		public byte[] GetAccounts(int clientId)
		{
			var accounts = _factory.GetAccoutnsService().GetAccounts(clientId);
			var htmlPre = "<html> <head> <meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\"/> <style> table { border: 1px solid silver; border - collapse:collapse; } table td { border - bottom:1px solid silver; }</style> </head><body>";
			var htmlPost = "</body></html>";
			var htmlMiddle1 = "<table><thead><tr><th class=\"col-md-1\">Numer</th><th class=\"col-md-8\">Nazwa</th><th class=\"col-xs-0\" style=\"width: 4%\"></th></tr></thead><tbody>";
			var htmlMiddle2 = "";
			var htmlMiddle3 = "</tbody></table>";

			foreach (var ac in accounts)
				htmlMiddle2 += $"<tr><td>{ac.Name}</td><td>{ac.Description}</td><td class=\"text-center\"></td></tr>";

			return GetPdf(htmlPre + htmlMiddle1 + htmlMiddle2 + htmlMiddle3 + htmlPost);
		}

		private byte[] GetPdf(string html)
		{
			var htmlContent = html;
			var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
			var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
			return pdfBytes;
		}
	}
}
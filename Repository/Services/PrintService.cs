using System;
using Repository.Abstract;

namespace Repository.Services
{
	public class PrintService : IPrintService
	{
		public byte[] GetAccounts(int clientId)
		{
			var htmlContent = String.Format("<body>Hello ąćżźółworld: {0}</body>", DateTime.Now);
			var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
			var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
			return pdfBytes;
		}
	}
}
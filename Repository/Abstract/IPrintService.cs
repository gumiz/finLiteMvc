namespace Repository.Abstract
{
	public interface IPrintService
	{
		string GetHtml();
		string GetPdf(int clientId, int year);
	}
}
namespace Repository.Abstract
{
	public interface IPrintService
	{
		string GetPdf(int clientId, int year);
	}
}
using System.Collections.Generic;
using Repository.Domain;

namespace Repository.Abstract
{
	public interface IReportsService
	{
		IList<Report> GetReports(int year, int clientId);
	}
}
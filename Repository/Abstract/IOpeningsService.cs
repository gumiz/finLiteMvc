using System.Collections.Generic;
using Repository.Domain;

namespace Repository.Abstract
{
	public interface IOpeningsService
	{
		IList<Opening> GetOpenings(int clientId, int year);
	}
}
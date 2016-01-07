using System.Collections.Generic;
using Repository.Domain;

namespace Repository.Abstract
{
	public interface IClientsService
	{
		IList<Client> GetClients();
	}
}
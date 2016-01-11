using System.Collections.Generic;
using System.Linq;
using Repository.Abstract;
using Repository.DAL;
using Repository.Domain;

namespace Repository.Services
{
	public class ClientsService : IClientsService
	{
		private readonly DefaultContext dbContext;

		public ClientsService(DefaultContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IList<Client> GetClients()
		{
			var dao = dbContext.Clients.ToList();
			var result = Converter.ConvertList<ClientDao, Client>(dao);
			return result;
		}
	}
}
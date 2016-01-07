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
//			dbContext.ClientDao.Add(new ClientDao { Id = 1, Name = "Równość", Description="Równość"});
//			dbContext.ClientDao.Add(new ClientDao { Id = 2, Name = "NET", Description = "NET" });
//			dbContext.ClientDao.Add(new ClientDao { Id = 3, Name = "Masyw", Description = "Masyw" });
//			dbContext.SaveChanges();
			var dao = dbContext.ClientDao.ToList();
			var result = Converter.ConvertList<ClientDao, Client>(dao);
			return result;
		}
	}
}
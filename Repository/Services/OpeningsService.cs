using System.Collections.Generic;
using System.Linq;
using Repository.Abstract;
using Repository.DAL;
using Repository.Domain;

namespace Repository.Services
{
	public class OpeningsService : IOpeningsService
	{
		private readonly DefaultContext dbContext;

		public OpeningsService(DefaultContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IList<Opening> GetOpenings(int clientId, int year)
		{
			var dao = dbContext.OpeningDao.Where(x => x.ClientId.Equals(clientId) && x.Year.Equals(year) ).ToList();
			var result = Converter.ConvertList<OpeningDao, Opening>(dao);
			return result;
		}
	}
}
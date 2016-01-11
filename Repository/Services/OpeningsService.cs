using System.Collections.Generic;
using System.Linq;
using Repository.Abstract;
using Repository.DAL;
using Repository.Domain;

namespace Repository.Services
{
	public class OpeningsService : IOpeningsService
	{
		private readonly DefaultContext _dbContext;

		public OpeningsService(DefaultContext dbContext)
		{
			this._dbContext = dbContext;
		}

		public IList<Opening> GetOpenings(int clientId, int year)
		{
			var dao = _dbContext.OpeningDao.Where(x => x.ClientId.Equals(clientId) && x.Year.Equals(year) ).ToList();
			var result = Converter.ConvertList<OpeningDao, Opening>(dao);
			return result;
		}

		public void SaveOpenings(List<Opening> openings)
		{
			var openingsDao = Converter.ConvertList<Opening, OpeningDao>(openings);
			_dbContext.OpeningDao.AddRange(openingsDao);
			_dbContext.SaveChanges();
		}
	}
}
using System.Collections.Generic;
using System.Linq;
using Repository.Abstract;
using Repository.DAL;
using Repository.Domain;

namespace Repository.Services
{
	public class ProfitLossService : IProfitLossService
	{
		private readonly DefaultContext _dbContext;

		public ProfitLossService(DefaultContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<ProfitAndLossReportItem> GetItems()
		{
			var itemsDao = _dbContext.ProfitLossReport.OrderBy(c=>c.Id).ToList();
			var items = Converter.ConvertList<ProfitAndLossReportItemDao, ProfitAndLossReportItem>(itemsDao);
			return items;

		}
	}
}
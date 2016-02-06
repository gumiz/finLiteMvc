using NUnit.Framework;
using Repository;
using Repository.Abstract;

namespace RepositoryTests
{
	public class ProfitAndLossServiceTest
	{
		private readonly IReportsService _service;

		public ProfitAndLossServiceTest()
		{
		}


		[Test]
		public void ReportExpensiveTest()
		{
			var factory = new Factory();
			var service = factory.GetProfitLossService();
			var result = service.GetValues(1, 2015);

			Assert.True(true);
		}
	}
}
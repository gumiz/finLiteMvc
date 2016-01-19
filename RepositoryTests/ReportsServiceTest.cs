using NSubstitute;
using NUnit.Framework;
using Repository;
using Repository.Abstract;

namespace RepositoryTests
{
	public class ReportsServiceTest
	{
		private readonly IReportsService _service;

		public ReportsServiceTest()
		{
			var factory = Substitute.For<IFactory>();
			_service = factory.GetReportsService();
		}

		[Test]
		public void ConverterTest()
		{
			var result = _service.GetReports(2015, 1);
			Assert.NotNull(result);
		}
	}
}
using NUnit.Framework;
using Repository;

namespace RepositoryTests
{
	public class BalancePrintServiceTest
	{
		public BalancePrintServiceTest()
		{
		}
		
		[Test]
		public void ReportExpensiveTest()
		{
			var factory = new Factory();
			var service = factory.GetBalancePrintService();
			service.GetPdf(1, 2015);
			var result = service.GetHtml();
			System.IO.File.WriteAllText(@"d:\_projects\FinLite\trunk\RepositoryTests\TestFiles\TestBalance.html", result);
			Assert.True(true);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Repository;
using Repository.Abstract;
using Repository.DAL;
using Repository.Services;

namespace RepositoryTests
{
	public class ReportsServiceTest
	{
		private readonly IReportsService _service;

		public ReportsServiceTest()
		{
		}

		[Test]
		public void ConverterTest()
		{
			var docs = new List<DocumentDao> {new DocumentDao {AccountCt = "100"}, new DocumentDao {AccountCt = "200"}};
			var result = LambdaTest(docs, d=>d.AccountCt);
			Assert.AreEqual(1, result.Count);
		}

		private List<DocumentDao> LambdaTest(List<DocumentDao> documents, Func<DocumentDao, string> documentProperty)
		{
			return documents.Where(c=>documentProperty.Invoke(c).Equals("100")).ToList();
		}

		[Test]
		public void ReportExpensiveTest()
		{
			var factory = new Factory();
			var service = factory.GetReportsService();
			var result = service.GetReports(2015, 1);

			Assert.True(true);
		}
	}
}
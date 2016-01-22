using System.Collections.Generic;
using AutoMapper;
using NUnit.Framework;
using Repository;
using Repository.DAL;
using Repository.Domain;
using Repository.Services;

namespace RepositoryTests
{
    public class AccountsServiceTest
    {
	    [Test]
	    public void ConverterTest()
	    {
		    var data = new List<AccountDao>();
			data.Add(new AccountDao {Name = "001", Description = "XXX"});
			Mapper.CreateMap<AccountDao, Account>();
			var result = Mapper.Map<List<AccountDao>, List<Account>>(data);
			Assert.AreEqual(1, result.Count);
	    }

		[Test]
		public void ConverterTest2()
		{
			var accountsDao = new List<AccountDao>();
			accountsDao.Add(new AccountDao { Name = "001", Description = "XXX" });
			var accounts = Converter.ConvertList<AccountDao, Account>(accountsDao);
			Assert.AreEqual(1, accounts.Count);
		}

	}
}

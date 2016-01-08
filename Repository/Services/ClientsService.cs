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
			var dao = dbContext.ClientDao.ToList();
			var result = Converter.ConvertList<ClientDao, Client>(dao);
			return result;
		}

		public void InitializeData()
		{
			InsertClients();
			InsertAccounts();
			InsertOpeningBalances();

			dbContext.SaveChanges();
		}

		private void InsertOpeningBalances()
		{
			var all = dbContext.OpeningDao.ToList();
			dbContext.OpeningDao.RemoveRange(all);
			dbContext.OpeningDao.Add(new OpeningDao {ClientId = 1, Year = 2016, Name = "100", Description = "Test1", Ct = 1000.95, Dt = 2000.99});
			dbContext.OpeningDao.Add(new OpeningDao {ClientId = 2, Year = 2016, Name = "100", Description = "Test2", Ct = 5900.95, Dt = 10000.99 });
		}

		private void InsertAccounts()
		{
			var all = dbContext.AccountDao.ToList();
			dbContext.AccountDao.RemoveRange(all);
			dbContext.AccountDao.Add(new AccountDao {Name = "100", Description = "KASA", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "130-01", Description = "RACHUNEK BIEŻĄCY", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "130-02", Description = "RACHUNEK - DOTACJA", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "200", Description = "ROZRACHUNKI Z KONTRAHENTAMI", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "220", Description = "ROZRACHUNKI PUBLICZNO-PRAWNE", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "230", Description = "ROZRACHUNKI Z TYTUŁU WYNAGRODZEŃ", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500",
				Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-01",
				Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH - DZIAŁALNOŚĆ PODSTAWOWA",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-02",
				Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH - DOTACJA 2014 FUNDUSZE EOG",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-02-01",
				Description = "ZAKUP ART.BIUROWYCH, MAT.DLA UCZESTNIKÓW,WYPOSAŻENIA",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao {Name = "500-02-02", Description = "USŁUGI CATERINGU", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "500-02-03", Description = "KOSZTY PODRÓŻY SŁUŻBOWYCH", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-02-04",
				Description = "WYNAGRODZENIA Z TYTUŁU UMÓW CYWILNOPRAWNYCH",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao {Name = "500-02-05", Description = "USŁUGI OBCE", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "510", Description = "KOSZTY ADMINISTRACYJNE", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "640",
				Description = "ROZLICZENIA MIĘDZYOKRESOWE KOSZTÓW",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "700",
				Description = "PRZYCHODY Z DZIAŁALNOŚCI STATUTOWEJ",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "700-01",
				Description = "SKŁADKI CZŁONKOWSKIE I STATUTOWE",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao {Name = "700-02", Description = "DOTACJA 2014 - FUNDUSZE EOG", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "700-03",
				Description = "DAROWIZNY NA DZIAŁALNOŚĆ STATUTOWĄ",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao {Name = "700-04", Description = "INNE", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "750", Description = "PRZYCHODY FINANSOWE", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "751", Description = "KOSZTY FINANSOWE", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "760", Description = "POZOSTAŁE PRZYCHODY NIE STATUTOWE", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "761", Description = "POZOSTAŁE KOSZTY NIE STATUTOWE", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "800", Description = "FUNDUSZE WŁASNE I CELOWE", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "820", Description = "ROZLICZENIE WYNIKU FINANSOWEGO", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "840",
				Description = "ROZLICZENIA MIĘDZYOKRESOWE PRZYCHODÓW",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao {Name = "860", Description = "WYNIK FINANSOWY", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "220-02", Description = "ROZRACHUNKI Z ZUS", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "220-01",
				Description = "PODATEK DOCHODOWY OD OSÓB FIZYCZNYCH",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao {Name = "700-05", Description = "DOTACJA 2015 FIO", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-03",
				Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH - DOTACJA FIO 2015",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-03-01",
				Description = "ZAKUP ARTYKUŁÓW BIUROWYCH, MAT.DLA UCZESTNIKÓW, WYPOSAŻENIA",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao {Name = "500-03-02", Description = "USŁUGI CATERINGOWE", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao {Name = "500-03-03", Description = "KOSZTY PODRÓŻY SŁUŻBOWYCH", ClientId = 1});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-03-04",
				Description = "WYNAGRODZENIA Z TYTUŁU UMÓW CYWILNOPRAWNYCH",
				ClientId = 1
			});
			dbContext.AccountDao.Add(new AccountDao {Name = "500-03-05", Description = "USŁUGI OBCE", ClientId = 1});

			dbContext.AccountDao.Add(new AccountDao {Name = "100", Description = "KASA", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "130", Description = "RACHUNEK BANKOWY", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "130-1", Description = "RACHUNEK PODSTAWOWY", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "130-2", Description = "RACHUNEK UM", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "130-3", Description = "RACHUNEK STAROSTWO", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "220", Description = "ROZRACHUNKI PUBLICZNO-PRAWNE", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "500", Description = "UM-TURNIEJ WIOSNA", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "501", Description = "UM-SZKOLENIE PIŁKA SIATKOWA", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "550", Description = "KOSZTY ADMINISTRACYJNE", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "700-1", Description = "ŹRÓDŁA PUBLICZNE", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "750", Description = "PRZYCHODY FINANSOWE", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "751", Description = "KOSZTY FINANSOWE", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "800", Description = "FUNDUSZ STATUTOWY", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao {Name = "860", Description = "WYNIK FINANSOWY", ClientId = 2});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "201",
				Description = "ROZRACHUNKI Z DOSTAWCAMI I ODBIORCAMI",
				ClientId = 2
			});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "502",
				Description = "STAROSTWO-SZKOLENIE PIŁKA SIATKOWA",
				ClientId = 2
			});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "700",
				Description = "PRZYCHODY Z DZIAŁALNOŚCI STATUTOWEJ",
				ClientId = 2
			});
			dbContext.AccountDao.Add(new AccountDao
			{
				Name = "701",
				Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH",
				ClientId = 2
			});
		}

		private void InsertClients()
		{
			var all = dbContext.ClientDao.ToList();
			dbContext.ClientDao.RemoveRange(all);
			dbContext.ClientDao.Add(new ClientDao {ClientId = 1, Name = "Równość", Description = "Równość"});
			dbContext.ClientDao.Add(new ClientDao {ClientId = 2, Name = "NET", Description = "NET"});
			dbContext.ClientDao.Add(new ClientDao {ClientId = 3, Name = "Masyw", Description = "Masyw"});
		}
	}
}
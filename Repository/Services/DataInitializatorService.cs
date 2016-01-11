using System.Linq;
using Repository.Abstract;
using Repository.DAL;

namespace Repository.Services
{
	public class DataInitializatorService : IDataInitializatorService
	{
		private readonly DefaultContext _dbContext;

		public DataInitializatorService(DefaultContext dbContext)
		{
			this._dbContext = dbContext;
		}


		public void InitializeData()
		{
			InsertClients();
			InsertAccounts();
			InsertOpeningBalances();

			_dbContext.SaveChanges();
		}

		private void InsertOpeningBalances()
		{
			var all = _dbContext.OpeningDao.ToList();
			_dbContext.OpeningDao.RemoveRange(all);
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "100", Description = "KASA", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "130-01", Description = "RACHUNEK BIEŻĄCY", Ct = 0, Dt = 140.87});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "130-02", Description = "RACHUNEK - DOTACJA", Ct = 0, Dt = 18472.37});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "200", Description = "ROZRACHUNKI Z KONTRAHENTAMI", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "220", Description = "ROZRACHUNKI PUBLICZNO-PRAWNE", Ct = 238.25, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "230", Description = "ROZRACHUNKI Z TYTUŁU WYNAGRODZEŃ", Ct = 0.01, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500", Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-01", Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH - DZIAŁALNOŚĆ PODSTAWOWA", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-02", Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH - DOTACJA 2014 FUNDUSZE EOG", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-02-01", Description = "ZAKUP ART.BIUROWYCH, MAT.DLA UCZESTNIKÓW,WYPOSAŻENIA", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-02-02", Description = "USŁUGI CATERINGU", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-02-03", Description = "KOSZTY PODRÓŻY SŁUŻBOWYCH", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-02-04", Description = "WYNAGRODZENIA Z TYTUŁU UMÓW CYWILNOPRAWNYCH", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-02-05", Description = "USŁUGI OBCE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "510", Description = "KOSZTY ADMINISTRACYJNE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "640", Description = "ROZLICZENIA MIĘDZYOKRESOWE KOSZTÓW", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "700", Description = "PRZYCHODY Z DZIAŁALNOŚCI STATUTOWEJ", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "700-01", Description = "SKŁADKI CZŁONKOWSKIE I STATUTOWE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "700-02", Description = "DOTACJA 2014 - FUNDUSZE EOG", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "700-03", Description = "DAROWIZNY NA DZIAŁALNOŚĆ STATUTOWĄ", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "700-04", Description = "INNE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "750", Description = "PRZYCHODY FINANSOWE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "751", Description = "KOSZTY FINANSOWE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "760", Description = "POZOSTAŁE PRZYCHODY NIE STATUTOWE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "761", Description = "POZOSTAŁE KOSZTY NIE STATUTOWE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "800", Description = "FUNDUSZE WŁASNE I CELOWE", Ct = 1000, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "820", Description = "ROZLICZENIE WYNIKU FINANSOWEGO", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "840", Description = "ROZLICZENIA MIĘDZYOKRESOWE PRZYCHODÓW", Ct = 18234.11, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "860", Description = "WYNIK FINANSOWY", Ct = 0, Dt = 859.13});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "220-02", Description = "ROZRACHUNKI Z ZUS", Ct = 137.25, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "220-01", Description = "PODATEK DOCHODOWY OD OSÓB FIZYCZNYCH", Ct = 101, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "700-05", Description = "DOTACJA 2015 FIO", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-03", Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH - DOTACJA FIO 2015", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-03-01", Description = "ZAKUP ARTYKUŁÓW BIUROWYCH, MAT.DLA UCZESTNIKÓW, WYPOSAŻENIA", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-03-02", Description = "USŁUGI CATERINGOWE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-03-03", Description = "KOSZTY PODRÓŻY SŁUŻBOWYCH", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-03-04", Description = "WYNAGRODZENIA Z TYTUŁU UMÓW CYWILNOPRAWNYCH", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 1, Name = "500-03-05", Description = "USŁUGI OBCE", Ct = 0, Dt = 0 });

			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "100", Description = "KASA", Ct = 0, Dt = 22.16});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "130", Description = "RACHUNEK BANKOWY", Ct = 0, Dt = 1598.33});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "130-1", Description = "RACHUNEK PODSTAWOWY", Ct = 0, Dt = 1592.89});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "130-2", Description = "RACHUNEK UM", Ct = 0, Dt = 4.7});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "130-3", Description = "RACHUNEK STAROSTWO", Ct = 0, Dt = 8.54});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "220", Description = "ROZRACHUNKI PUBLICZNO-PRAWNE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "500", Description = "UM-TURNIEJ WIOSNA", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "501", Description = "UM-SZKOLENIE PIŁKA SIATKOWA", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "550", Description = "KOSZTY ADMINISTRACYJNE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "700-1", Description = "ŹRÓDŁA PUBLICZNE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "750", Description = "PRZYCHODY FINANSOWE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "751", Description = "KOSZTY FINANSOWE", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "800", Description = "FUNDUSZ STATUTOWY", Ct = 5886.16, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "860", Description = "WYNIK FINANSOWY", Ct = 0, Dt = 4273.82});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "201", Description = "ROZRACHUNKI Z DOSTAWCAMI I ODBIORCAMI", Ct = 5.22, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "502", Description = "STAROSTWO-SZKOLENIE PIŁKA SIATKOWA", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "700", Description = "PRZYCHODY Z DZIAŁALNOŚCI STATUTOWEJ", Ct = 0, Dt = 0});
			_dbContext.OpeningDao.Add(new OpeningDao { Year = 2015, ClientId = 2, Name = "701", Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH", Ct = 0, Dt = 0});

		}

		private void InsertAccounts()
		{
			var all = _dbContext.AccountDao.ToList();
			_dbContext.AccountDao.RemoveRange(all);
			_dbContext.AccountDao.Add(new AccountDao { Name = "100", Description = "KASA", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "130-01", Description = "RACHUNEK BIEŻĄCY", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "130-02", Description = "RACHUNEK - DOTACJA", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "200", Description = "ROZRACHUNKI Z KONTRAHENTAMI", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "220", Description = "ROZRACHUNKI PUBLICZNO-PRAWNE", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "230", Description = "ROZRACHUNKI Z TYTUŁU WYNAGRODZEŃ", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500",
				Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-01",
				Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH - DZIAŁALNOŚĆ PODSTAWOWA",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-02",
				Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH - DOTACJA 2014 FUNDUSZE EOG",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-02-01",
				Description = "ZAKUP ART.BIUROWYCH, MAT.DLA UCZESTNIKÓW,WYPOSAŻENIA",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao { Name = "500-02-02", Description = "USŁUGI CATERINGU", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "500-02-03", Description = "KOSZTY PODRÓŻY SŁUŻBOWYCH", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-02-04",
				Description = "WYNAGRODZENIA Z TYTUŁU UMÓW CYWILNOPRAWNYCH",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao { Name = "500-02-05", Description = "USŁUGI OBCE", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "510", Description = "KOSZTY ADMINISTRACYJNE", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "640",
				Description = "ROZLICZENIA MIĘDZYOKRESOWE KOSZTÓW",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "700",
				Description = "PRZYCHODY Z DZIAŁALNOŚCI STATUTOWEJ",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "700-01",
				Description = "SKŁADKI CZŁONKOWSKIE I STATUTOWE",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao { Name = "700-02", Description = "DOTACJA 2014 - FUNDUSZE EOG", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "700-03",
				Description = "DAROWIZNY NA DZIAŁALNOŚĆ STATUTOWĄ",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao { Name = "700-04", Description = "INNE", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "750", Description = "PRZYCHODY FINANSOWE", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "751", Description = "KOSZTY FINANSOWE", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "760", Description = "POZOSTAŁE PRZYCHODY NIE STATUTOWE", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "761", Description = "POZOSTAŁE KOSZTY NIE STATUTOWE", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "800", Description = "FUNDUSZE WŁASNE I CELOWE", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "820", Description = "ROZLICZENIE WYNIKU FINANSOWEGO", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "840",
				Description = "ROZLICZENIA MIĘDZYOKRESOWE PRZYCHODÓW",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao { Name = "860", Description = "WYNIK FINANSOWY", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "220-02", Description = "ROZRACHUNKI Z ZUS", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "220-01",
				Description = "PODATEK DOCHODOWY OD OSÓB FIZYCZNYCH",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao { Name = "700-05", Description = "DOTACJA 2015 FIO", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-03",
				Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH - DOTACJA FIO 2015",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-03-01",
				Description = "ZAKUP ARTYKUŁÓW BIUROWYCH, MAT.DLA UCZESTNIKÓW, WYPOSAŻENIA",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao { Name = "500-03-02", Description = "USŁUGI CATERINGOWE", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "500-03-03", Description = "KOSZTY PODRÓŻY SŁUŻBOWYCH", ClientId = 1 });
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "500-03-04",
				Description = "WYNAGRODZENIA Z TYTUŁU UMÓW CYWILNOPRAWNYCH",
				ClientId = 1
			});
			_dbContext.AccountDao.Add(new AccountDao { Name = "500-03-05", Description = "USŁUGI OBCE", ClientId = 1 });

			_dbContext.AccountDao.Add(new AccountDao { Name = "100", Description = "KASA", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "130", Description = "RACHUNEK BANKOWY", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "130-1", Description = "RACHUNEK PODSTAWOWY", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "130-2", Description = "RACHUNEK UM", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "130-3", Description = "RACHUNEK STAROSTWO", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "220", Description = "ROZRACHUNKI PUBLICZNO-PRAWNE", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "500", Description = "UM-TURNIEJ WIOSNA", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "501", Description = "UM-SZKOLENIE PIŁKA SIATKOWA", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "550", Description = "KOSZTY ADMINISTRACYJNE", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "700-1", Description = "ŹRÓDŁA PUBLICZNE", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "750", Description = "PRZYCHODY FINANSOWE", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "751", Description = "KOSZTY FINANSOWE", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "800", Description = "FUNDUSZ STATUTOWY", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao { Name = "860", Description = "WYNIK FINANSOWY", ClientId = 2 });
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "201",
				Description = "ROZRACHUNKI Z DOSTAWCAMI I ODBIORCAMI",
				ClientId = 2
			});
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "502",
				Description = "STAROSTWO-SZKOLENIE PIŁKA SIATKOWA",
				ClientId = 2
			});
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "700",
				Description = "PRZYCHODY Z DZIAŁALNOŚCI STATUTOWEJ",
				ClientId = 2
			});
			_dbContext.AccountDao.Add(new AccountDao
			{
				Name = "701",
				Description = "KOSZTY REALIZACJI ZADAŃ STATUTOWYCH",
				ClientId = 2
			});
		}

		private void InsertClients()
		{
			var all = _dbContext.ClientDao.ToList();
			_dbContext.ClientDao.RemoveRange(all);
			_dbContext.ClientDao.Add(new ClientDao { ClientId = 1, Name = "Równość", Description = "Równość" });
			_dbContext.ClientDao.Add(new ClientDao { ClientId = 2, Name = "NET", Description = "NET" });
			_dbContext.ClientDao.Add(new ClientDao { ClientId = 3, Name = "Masyw", Description = "Masyw" });
		}

	}
}
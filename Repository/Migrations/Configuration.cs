using System.Data.Entity.Validation;
using Repository.DAL;

namespace Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.DAL.DefaultContext>
    {
	    private DefaultContext _context;

	    public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Repository.DAL.DefaultContext";
        }

        protected override void Seed(Repository.DAL.DefaultContext context)
        {
	        _context = context;
	        var clients = _context.Clients.ToList();
	        foreach (var client in clients)
	        {
		        SeedProfitAndLossReportForClient(client.ClientId);
		        SeedBalanceReportForClient(client.ClientId);
	        }
	        try
			{
				_context.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				foreach (var eve in e.EntityValidationErrors)
				{
					Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
							ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}

			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
		}

	    private void SeedBalanceReportForClient(int clientId)
	    {
			if (_context.BalanceReport.ToList().Count != 0) return;
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 1, ClientId = clientId, IsBold = true, IsReadOnly = true, Type = "AKTYWA", Number = "A", Description = "Aktywa trwałe"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 2, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "AKTYWA", Number = "I", Description = "Wartości niematerialne i prawne"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 3, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "AKTYWA", Number = "II", Description = "Rzeczowe aktywa trwałe"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 4, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "AKTYWA", Number = "III",Description = "Należności długoterminowe"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 5, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "AKTYWA", Number = "IV", Description = "Inwestycje długoterminowe"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 6, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "AKTYWA", Number = "V", Description = "Długoterminowe rozliczenia międzyokresowe"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 7, ClientId = clientId, IsBold = true, IsReadOnly = true, Type = "AKTYWA", Number = "B", Description = "Aktywa obrotowe"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 8, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "AKTYWA", Number = "I", Description = "Zapasy rzeczowych aktywów obrotowych"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 9, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "AKTYWA", Number = "II", Description = "Należności krótkoterminowe"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 10, ClientId = clientId, IsBold = false, IsReadOnly = true, Type = "AKTYWA", Number = "III", Description = "Inwestycje krótkoterminowe"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 11, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "AKTYWA", Number = "1", Description = "Środki pieniężne"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 12, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "AKTYWA", Number = "2", Description = "Pozostałe aktywa finansowe"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 13, ClientId = clientId, IsBold = true, IsReadOnly = false, Type = "AKTYWA", Number = "C", Description = "Krótkoterminowe rozliczenia międzyokresowe"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 14, ClientId = clientId, IsBold = true, IsReadOnly = true, Type = "AKTYWA", Number = "", Description = "SUMA AKTYWÓW"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 15, ClientId = clientId, IsBold = true, IsReadOnly = true, Type = "PASYWA", Number = "A", Description = "Fundusze własne"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 16, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "PASYWA", Number = "I", Description = "Fundusz statutowy"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 17, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "PASYWA", Number = "II", Description = "Fundusz z aktualizacji wyceny"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 18, ClientId = clientId, IsBold = false, IsReadOnly = true, Type = "PASYWA", Number = "III", Description = "Wynik finansowy netto za rok obrotowy"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 19, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "PASYWA", Number = "1", Description = "Nadwyżka przychodów nad kosztami[wielkość dodatnia]"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 20, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "PASYWA", Number = "2", Description = "Nadwyżka kosztów nad przychodami[wielkość ujemna]"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 21, ClientId = clientId, IsBold = true, IsReadOnly = true, Type = "PASYWA", Number = "B", Description = "Zobowiązania i rezerwy na zobowiązania"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 22, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "PASYWA", Number = "I", Description = "Zobowiązania długoterminowe z tytułu kredytów i pożyczek"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 23, ClientId = clientId, IsBold = false, IsReadOnly = true, Type = "PASYWA", Number = "II", Description = "Zobowiązania krótkoterminowe i fundusze specjalne"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 24, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "PASYWA", Number = "1", Description = "Kredyty i pożyczki"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 25, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "PASYWA", Number = "2", Description = "Inne zobowiązania"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 26, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "PASYWA", Number = "3", Description = "Fundusze specjalne"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 27, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "PASYWA", Number = "III",Description = "Rezerwy na zobowiązania"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 28, ClientId = clientId, IsBold = false, IsReadOnly = true, Type = "PASYWA", Number = "IV", Description = "Rozliczenia międzyokresowe"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 29, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "PASYWA", Number = "1", Description = "Rozliczenia międzyokresowe przychodów"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 30, ClientId = clientId, IsBold = false, IsReadOnly = false, Type = "PASYWA", Number = "2", Description = "Inne rozl.międzyokresowe"});
			_context.BalanceReport.AddOrUpdate(new BalanceReportItemDao { RowId = 31, ClientId = clientId, IsBold = false, IsReadOnly = true, Type = "PASYWA", Number = "", Description = "SUMA PASYWÓW"});
		}

		private void SeedProfitAndLossReportForClient(int clientId)
	    {
		    if (_context.ProfitLossReport.ToList().Count != 0) return;
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 1, ClientId = clientId, IsBold = true, IsReadOnly = true, Number = "A", Formula = "", Description = "Przychody z działalności statutowej" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 2, ClientId = clientId, IsBold = false, IsReadOnly = false, Number = "I", Formula = "", Description = "Składki brutto określone statutem" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 3, ClientId = clientId, IsBold = false, IsReadOnly = false, Number = "II", Formula = "", Description = "Inne przychody określone statutem" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 4, ClientId = clientId, IsBold = true, IsReadOnly = false, Number = "B", Formula = "", Description = "Koszty realizacji zadań statutowych" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 5, ClientId = clientId, IsBold = true, IsReadOnly = true, Number = "C", Formula = "", Description = "Wynik finansowy na działalności statutowej[A - B]" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 6, ClientId = clientId, IsBold = true, IsReadOnly = true, Number = "D", Formula = "", Description = "Koszty administracyjne" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 7, ClientId = clientId, IsBold = false, IsReadOnly = false, Number = "1", Formula = "", Description = "Zużycie materiałów i energii" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 8, ClientId = clientId, IsBold = false, IsReadOnly = false, Number = "2", Formula = "", Description = "Usługi obce" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 9, ClientId = clientId, IsBold = false, IsReadOnly = false, Number = "3", Formula = "", Description = "Podatki i opłaty" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 10, ClientId = clientId, IsBold = false, IsReadOnly = false, Number = "4", Formula = "", Description = "Wynagrodzenia oraz ubezpieczenia społeczne i inne świadczenia" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 11, ClientId = clientId, IsBold = false, IsReadOnly = false, Number = "5", Formula = "", Description = "Amortyzacja" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 12, ClientId = clientId, IsBold = false, IsReadOnly = false, Number = "6", Formula = "", Description = "Pozostałe" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 13, ClientId = clientId, IsBold = true, IsReadOnly = false, Number = "E", Formula = "", Description = "Pozostałe przychody" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 14, ClientId = clientId, IsBold = true, IsReadOnly = false, Number = "F", Formula = "", Description = "Pozostałe koszty" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 15, ClientId = clientId, IsBold = true, IsReadOnly = false, Number = "G", Formula = "", Description = "Przychody finansowe" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 16, ClientId = clientId, IsBold = true, IsReadOnly = false, Number = "H", Formula = "", Description = "Koszty finansowe" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 17, ClientId = clientId, IsBold = true, IsReadOnly = true, Number = "I", Formula = "", Description = "Wynik finansowy brutto na całokształcie działalności[C - D + E - F + G - H]" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 18, ClientId = clientId, IsBold = true, IsReadOnly = false, Number = "J", Formula = "", Description = "Zyski i straty nadzwyczajne" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 19, ClientId = clientId, IsBold = true, IsReadOnly = true, Number = "K", Formula = "", Description = "Wynik finansowy ogółem[I + J]" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 20, ClientId = clientId, IsBold = false, IsReadOnly = true, Number = "I", Formula = "", Description = "Różnica zwiększająca koszty roku następnego[wielkość ujemna]" });
			_context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { RowId = 21, ClientId = clientId, IsBold = false, IsReadOnly = true, Number = "II", Formula = "", Description = "Różnica zwiększająca przychody roku następnego[wielkość dodatnia]" });
		}
	}
}

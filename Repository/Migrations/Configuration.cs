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
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Repository.DAL.DefaultContext";
        }

        protected override void Seed(Repository.DAL.DefaultContext context)
        {
	        if (context.ProfitLossReport.ToList().Count == 0) {
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 1, Number = "A", Formula = "", Description = "Przychody z działalności statutowej"});
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 2, Number = "I", Formula = "", Description = "Składki brutto określone statutem" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 3, Number = "II",Formula = "", Description = "Inne przychody określone statutem" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 4, Number = "B", Formula = "", Description = "Koszty realizacji zadań statutowych" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 5, Number = "C", Formula = "", Description = "Wynik finansowy na działalności statutowej[A - B]" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 6, Number = "D", Formula = "", Description = "Koszty administracyjne" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 7, Number = "1", Formula = "", Description = "Zużycie materiałów i energii" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 8, Number = "2", Formula = "", Description = "Usługi obce" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 9, Number = "3", Formula = "", Description = "Podatki i opłaty" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 10, Number = "4", Formula = "", Description = "Wynagrodzenia oraz ubezpieczenia społeczne i inne świadczenia" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 11, Number = "5", Formula = "", Description = "Amortyzacja" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 12, Number = "6", Formula = "", Description = "Pozostałe" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 13, Number = "E", Formula = "", Description = "Pozostałe przychody" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 14, Number = "F", Formula = "", Description = "Pozostałe koszty" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 15, Number = "G", Formula = "", Description = "Przychody finansowe" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 16, Number = "H", Formula = "", Description = "Koszty finansowe" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 17, Number = "I", Formula = "", Description = "Wynik finansowy brutto na całokształcie działalności[C - D + E - F + G - H]" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 18, Number = "J", Formula = "", Description = "Zyski i straty nadzwyczajne" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 19, Number = "K", Formula = "", Description = "Wynik finansowy ogółem[I + J]" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 20, Number = "I", Formula = "", Description = "Różnica zwiększająca koszty roku następnego[wielkość ujemna]" });
				context.ProfitLossReport.AddOrUpdate(new ProfitAndLossReportItemDao { Id = 21, Number = "II",Formula = "", Description = "Różnica zwiększająca przychody roku następnego[wielkość dodatnia]" });
			}
			try
			{
				context.SaveChanges();
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
    }
}

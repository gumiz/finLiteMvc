using System.Collections.Generic;
using System.Web.Mvc;
using Rekord.Pfk.PortalFb.ApplicationBoundary.Abstract;
using Rekord.Pfk.PortalFb.VatRegistryBoundary.Requests;
using Rekord.Pfk.PortalFbMvc.Abstract.Factories;

namespace Rekord.Pfk.PortalFbMvc.Controllers.Dictionaries.VatStaff
{
	public class Vat7ConfigController : PortalFbController
	{
		public Vat7ConfigController(IMvcObjectFactory mvcObjectFactory, IApplication application)
			: base(mvcObjectFactory, application)
		{
		}

		public ViewResult Index()
		{
			ValidateLicence(GetType().Name);
			return View("Vat7Config");
		}

		public ActionResult GetItems(int version)
		{
			var result = MockItems();
			return new JsonResult { Data = result };
		}

		public ActionResult GetRegistries()
		{
			var request = new GetVatRegistriesRequest();
			var response = Application.Execute(request);
			return Json(response, JsonRequestBehavior.AllowGet);
		}

		public ActionResult GetVatRates()
		{
			var request = new GetVatRatesRequest();
			var response = Application.Execute(request);
			return Json(response, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SaveItem(Vat7Item item)
		{
			var request = new Vat7SaveItemRequest { Item = item };
			return AppExecute(request, response => true);
			return new JsonResult { Data = true };
		}

		public ActionResult DeleteItem(int id)
		{
			var request = new Vat7DeleteItemRequest { Item = item };
			return AppExecute(request, response => true);
			return new JsonResult { Data = true };
		}
		
		private IList<Vat7ConfigItem> MockItems() {
			var result = new List<Vat7ConfigItem>();
			result.Add(new Vat7ConfigItem { Id = 1, Symbol = "C.01", Description = "Jakiś opis", Type = new CurrencyType {Symbol = 0, Description = "Kwota netto"}, VatRate = "", Registries = new List<string> {"01", "02" } });
			result.Add(new Vat7ConfigItem { Id = 2, Symbol = "C.02", Description = "Jakiś opis dłuższy", Type = new CurrencyType { Symbol = 1, Description = "Kwota vat" }, VatRate = "", Registries = new List<string> { "01" } });
			result.Add(new Vat7ConfigItem { Id = 3, Symbol = "C.03", Description = "Jakiś opis bardzo długi z wieloma znakami", Type = new CurrencyType { Symbol = 2, Description = "Kwota brutto" }, VatRate = "05", Registries = new List<string> { "01", "02" } });
			result.Add(new Vat7ConfigItem { Id = 4, Symbol = "C.03", Description = "Test1" });
			result.Add(new Vat7ConfigItem { Id = 5, Symbol = "C.03", Description = "Test2" });
			return result;
		}
	}
}
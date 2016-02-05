using System.Web.Mvc;
using Repository.Abstract;

namespace WebApplication.Controllers
{
	public class CreatorsController : Controller
	{
		private IFactory _factory;

		public CreatorsController(IFactory factory)
		{
			_factory = factory;
		}

		public ActionResult ProfitLoss()
		{
			return View("profitLoss");
		}

		[HttpPost]
		public ActionResult GetProfitLossItems()
		{
			var result = _factory.GetProfitLossService().GetItems();
			return new JsonResult {Data = result};
		}

		[HttpGet]
		public ActionResult PrintProfitLoss(int clientId, int year)
		{
			var pdf = _factory.GetProfitLossPrintService().GetPdf(clientId, year);
			return new JsonResult { Data = pdf, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

	}
}
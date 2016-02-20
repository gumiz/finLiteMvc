using System.Collections.Generic;
using System.Web.Mvc;
using Repository.Abstract;
using Repository.Domain;

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

		public ActionResult Balance()
		{
			return View("balance");
		}

		[HttpPost]
		public ActionResult GetProfitLossItems(int clientId)
		{
			var result = _factory.GetProfitLossService().GetItems(clientId);
			return new JsonResult {Data = result};
		}

		[HttpPost]
		public ActionResult SaveProfitLossItems(int clientId, IList<ProfitAndLossReportItem> items )
		{
			_factory.GetProfitLossService().SaveItems(clientId, items);
			return new JsonResult { Data = true };
		}

		[HttpGet]
		public ActionResult PrintProfitLoss(int clientId, int year)
		{
			var pdf = _factory.GetProfitLossPrintService().GetPdf(clientId, year);
			return new JsonResult { Data = pdf, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		[HttpPost]
		public ActionResult GetBalanceItems(int clientId)
		{
			var result = _factory.GetBalanceService().GetItems(clientId);
			return new JsonResult { Data = result };
		}

		[HttpPost]
		public ActionResult SaveBalanceItems(int clientId, BalanceItems items)
		{
			_factory.GetBalanceService().SaveItems(clientId, items);
			return new JsonResult { Data = true };
		}

		[HttpGet]
		public ActionResult PrintBalance(int clientId, int year)
		{
			var pdf = _factory.GetBalancePrintService().GetPdf(clientId, year);
			return new JsonResult { Data = pdf, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}
	}
}
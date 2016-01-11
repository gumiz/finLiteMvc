using System.Collections.Generic;
using System.Web.Mvc;
using Repository.Abstract;
using Repository.Domain;

namespace WebApplication.Controllers
{
	public class OpeningBalanceController : Controller
	{
		private readonly IFactory _factory;

		public OpeningBalanceController(IFactory factory)
		{
			_factory = factory;
		}

		public ActionResult Index()
		{
			return View("openingBalance");
		}

		public ActionResult GetOpenings(int clientId, int year)
		{
			var result = _factory.GetOpeningsService().GetOpenings(clientId, year);
			return new JsonResult {Data = result};
		}

		public ActionResult SaveOpenings(List<Opening> openings)
		{
			_factory.GetOpeningsService().SaveOpenings(openings);
			return new JsonResult { Data = true };
		}
	}
}
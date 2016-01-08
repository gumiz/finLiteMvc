using System.Web.Mvc;
using Repository.Abstract;

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
	}
}
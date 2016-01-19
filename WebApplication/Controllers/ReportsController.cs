using System.Web.Mvc;
using Repository.Abstract;

namespace WebApplication.Controllers
{
	public class ReportsController : Controller
	{
		private readonly IFactory _factory;

		public ReportsController(IFactory factory)
		{
			_factory = factory;
		}

		public ActionResult Index()
		{
			return View("reports");
		}

		public ActionResult GetReports(int year, int clientId)
		{
			var documents = _factory.GetReportsService().GetReports(year, clientId);
			return new JsonResult { Data = documents };
		}

	}
}
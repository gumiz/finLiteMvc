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

		[HttpGet]
		public ActionResult Print(int clientId, int year)
		{
			var pdf = _factory.GetReportsPrintService().GetPdf(clientId, year);
			return new JsonResult { Data = pdf, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

	}
}
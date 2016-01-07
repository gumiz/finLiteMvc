using System.Web.Mvc;

namespace WebApplication.Controllers
{
	public class ReportsController : Controller
	{
		public ActionResult Index()
		{
			return View("reports");
		}
	}
}
using System.Web.Mvc;

namespace WebApplication.Controllers
{
	public class OpeningBalanceController : Controller
	{
		public ActionResult Index()
		{
			return View("openingBalance");
		}
	}
}
using System.Web.Mvc;

namespace WebApplication.Controllers
{
	public class DocumentsController : Controller
	{
		public ActionResult Index()
		{
			return View("documents");
		}

	}
}
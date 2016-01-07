using System.Web.Mvc;
using Repository.Abstract;

namespace WebApplication.Controllers
{
	public class AccountsController : Controller
	{
		private IFactory _factory;

		public AccountsController(IFactory factory)
		{
			_factory = factory;
		}

		public ActionResult Index()
		{
			return View("accounts");
		}

		[HttpGet]
		public ActionResult GetAccounts()
		{
			var accounts = _factory.GetAccoutnsService().GetAccounts();
			return new JsonResult {Data = accounts, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
		}
	}
}
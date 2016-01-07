using System.Web.Mvc;
using Repository.Abstract;
using Repository.Domain;

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

		[HttpPost]
		public ActionResult AddAccount(Account account)
		{
			_factory.GetAccoutnsService().AddAccount(account);
			return new JsonResult { Data = true };
		}

		[HttpPost]
		public ActionResult DeleteAccount(string name)
		{
			_factory.GetAccoutnsService().DeleteAccount(name);
			return new JsonResult { Data = true };
		}
	}
}
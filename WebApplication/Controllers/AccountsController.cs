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

		[HttpPost]
		public ActionResult GetAccounts(int clientId)
		{
			var accounts = _factory.GetAccoutnsService().GetAccounts(clientId);
			return new JsonResult {Data = accounts};
		}

		[HttpPost]
		public ActionResult AddAccount(Account account)
		{
			_factory.GetAccoutnsService().AddAccount(account);
			return new JsonResult { Data = true };
		}

		[HttpPost]
		public ActionResult DeleteAccount(Account account)
		{
			_factory.GetAccoutnsService().DeleteAccount(account);
			return new JsonResult { Data = true };
		}
	}
}
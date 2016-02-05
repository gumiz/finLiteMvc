using System.Web.Mvc;
using Repository.Abstract;
using Repository.Domain;

namespace WebApplication.Controllers
{
	public class AccountsController : Controller
	{
		private readonly IFactory _factory;

		public AccountsController(IFactory factory)
		{
			_factory = factory;
		}

		public ActionResult Index()
		{
			return View("accounts");
		}

		[HttpPost]
		public ActionResult GetAccounts(int clientId, int year)
		{
			var accounts = _factory.GetAccoutnsService().GetAccounts(clientId, year);
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

		[HttpPost]
		public ActionResult RewriteAccountsWithLastYear(int clientId, int year)
		{
			_factory.GetAccoutnsService().RewriteAccountsWithLastYear(clientId, year);
			return new JsonResult { Data = true };
		}

		[HttpGet]
		public ActionResult Print(int clientId, int year)
		{
			var pdf = _factory.GetAccountsPrintService().GetPdf(clientId, year);
			return new JsonResult {Data = pdf, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
		}

	}
}
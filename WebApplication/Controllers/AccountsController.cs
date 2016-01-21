using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
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

		[HttpGet]
		public ActionResult Print(int clientId)
		{
			var pdfBytes = _factory.GetPrintService().GetAccounts(clientId);
			var base64EncodedPDF = System.Convert.ToBase64String(pdfBytes);
			return new JsonResult {Data = base64EncodedPDF, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
		}

	}
}
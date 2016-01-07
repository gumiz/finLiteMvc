using System.Web.Mvc;
using Repository.Abstract;

namespace WebApplication.Controllers
{
	public class ClientsController : Controller
	{
		private IFactory _factory;

		public ClientsController(IFactory factory)
		{
			_factory = factory;
		}

		[HttpPost]
		public ActionResult GetClients()
		{
			var result = _factory.GetClientsService().GetClients();
			return new JsonResult {Data = result};
		}
	}
}
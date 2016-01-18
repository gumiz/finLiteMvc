﻿using System.Web.Mvc;
using Repository.Abstract;

namespace WebApplication.Controllers
{
	public class DocumentsController : Controller
	{
		private IFactory _factory;

		public DocumentsController(IFactory factory)
		{
			_factory = factory;
		}


		public ActionResult Index()
		{
			return View("documents");
		}

		public ActionResult GetDocuments(int year, int clientId)
		{
			var documents = _factory.GetDocumentsService().GetDocuments(year, clientId);
			return new JsonResult { Data = documents };
		}

		public ActionResult DeleteDocument(int id)
		{
			_factory.GetDocumentsService().DeleteDocument(id);
			return new JsonResult { Data = true };
		}

		//		[HttpPost]
		//		public ActionResult AddAccount(Account account)
		//		{
		//			_factory.GetAccoutnsService().AddAccount(account);
		//			return new JsonResult { Data = true };
		//		}

	}
}
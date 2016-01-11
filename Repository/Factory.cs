﻿using Repository.Abstract;
using Repository.DAL;
using Repository.Services;

namespace Repository
{
	public class Factory : IFactory
	{
		public Factory()
		{
			var dbContext = new DefaultContext();
			AccountsService = new AccountsService(dbContext);
			ClientsService = new ClientsService(dbContext);
			OpeningsService = new OpeningsService(dbContext);
			DocumentsService = new DocumentsService(dbContext);
			DataInitializatorService = new DataInitializatorService(dbContext);
		}

		public AccountsService AccountsService { get; set; }
		public IClientsService ClientsService { get; set; }
		public IOpeningsService OpeningsService { get; set; }
		public IDocumentsService DocumentsService { get; set; }
		public IDataInitializatorService DataInitializatorService { get; set; }

		public IAccountsService GetAccoutnsService()
		{
			return AccountsService;
		}

		public IClientsService GetClientsService()
		{
			return ClientsService;
		}

		public IOpeningsService GetOpeningsService()
		{
			return OpeningsService;
		}

		public IDataInitializatorService GetDataInitializatorService()
		{
			return DataInitializatorService;
		}

		public IDocumentsService GetDocumentsService()
		{
			return DocumentsService;
		}
	}
}
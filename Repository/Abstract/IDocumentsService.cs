﻿using System.Collections.Generic;
using Repository.Domain;

namespace Repository.Abstract
{
	public interface IDocumentsService
	{
		IList<Document> GetDocuments(int year, int clientId);
		void DeleteDocument(int id);
		void AddDocument(Document document);
		void UpdateDocument(Document document);
	}
}
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Repository.Abstract;
using Repository.DAL;
using Repository.Domain;

namespace Repository.Services
{
	public class DocumentsService : IDocumentsService
	{
		private readonly DefaultContext _dbContext;
		private int _autoNumber;
		private List<DocumentDao> _allDocs;

		public DocumentsService(DefaultContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<Document> GetDocuments(int year, int clientId)
		{
			var documentsDao = _dbContext.Documents.Where(x=>x.Year.Equals(year) && x.ClientId.Equals(clientId)).OrderBy(x=>x.AutoNumber).ToList();
			var documents = Converter.ConvertList<DocumentDao, Document>(documentsDao);
			return documents;
		}

		public void DeleteDocument(int id)
		{
			var document = _dbContext.Documents.FirstOrDefault(c => c.Id.Equals(id));
			_dbContext.Documents.Remove(document);
			_dbContext.SaveChanges();
		}

		public void AddDocument(Document document)
		{
			document.Year = document.Date.Year;
			SetAutoNumber(document);
			var documentDao = Converter.Convert<Document, DocumentDao>(document);
			_dbContext.Documents.AddOrUpdate(documentDao);
			_dbContext.SaveChanges();
		}

		private void SetAutoNumber(Document document)
		{
			if (document.AutoNumber > 0) return;
			_allDocs = _dbContext.Documents.Where(c => c.Year.Equals(document.Date.Year) && c.ClientId.Equals(document.ClientId)).ToList();
			_autoNumber = 1;
			if (_allDocs.Any())
			{
				_autoNumber = _allDocs.Max(c => c.AutoNumber);
				_autoNumber++;
			}
			document.AutoNumber = _autoNumber;
		}
	}
}
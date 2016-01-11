using System.Collections.Generic;
using System.Linq;
using Repository.Abstract;
using Repository.DAL;
using Repository.Domain;

namespace Repository.Services
{
	public class DocumentsService : IDocumentsService
	{
		private readonly DefaultContext _dbContext;

		public DocumentsService(DefaultContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<Document> GetDocuments(int year, int clientId)
		{
			var documentsDao = _dbContext.Documents.Where(x=>x.Year.Equals(year) && x.ClientId.Equals(clientId)).ToList();
			var documents = Converter.ConvertList<DocumentDao, Document>(documentsDao);
			return documents;
		}
	}
}
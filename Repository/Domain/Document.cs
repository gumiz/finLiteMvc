using System;

namespace Repository.Domain
{
	public class Document
	{
		public int Id { get; set; }

		public int ClientId { get; set; }

		public int Year { get; set; }

		public int AutoNumber { get; set; }

		public DateTime Date { get; set; }

		public string Number { get; set; }

		public string Description { get; set; }

		public double Price { get; set; }

		public string AccountCt { get; set; }

		public string AccountDt { get; set; }
	}
}
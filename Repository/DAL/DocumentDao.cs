using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DAL
{
	[Table("Fin_Documents")]
	public class DocumentDao
	{
		[Key, Column("ID"), Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Column("CLIENT_ID"), Required]
		public int ClientId { get; set; }

		[Column("AUTO_NUMBER"), Required]
		public int AutoNumber { get; set; }

		[Column("YEAR"), Required]
		public int Year { get; set; }

		[Column("DATE"), Required]
		public DateTime Date { get; set; }

		[Column("NUMBER"), Required]
		public string Number { get; set; }

		[Column("DESCRIPTION"), Required]
		public string Description { get; set; }

		[Column("PRICE"), Required]
		public double Price { get; set; }

		[Column("ACCOUNT_CT"), Required]
		public string AccountCt { get; set; }

		[Column("ACCOUNT_DT"), Required]
		public string AccountDt { get; set; }
	}
}
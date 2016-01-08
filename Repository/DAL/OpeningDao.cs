using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DAL
{
	[Table("Fin_OpeningBalances")]
	public class OpeningDao
	{
		[Key, Column("ID"), Required]
		public int Id { get; set; }

		[Column("CLIENT_ID"), Required]
		public int ClientId { get; set; }

		[Column("YEAR"), Required]
		public int Year { get; set; }

		[Column("NAME"), Required]
		public string Name { get; set; }

		[Column("DESCRIPTION"), Required]
		public string Description { get; set; }

		[Column("CT"), Required]
		public double Ct { get; set; }

		[Column("DT"), Required]
		public double Dt { get; set; }

	}
}
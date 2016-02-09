using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DAL
{
	[Table("Fin_Reports_ProfitLoss")]
	public class ProfitAndLossReportItemDao
	{
		[Key, Column("ID"), Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Column("CLIENT_ID"), Required]
		public int ClientId { get; set; }

		[Column("ROW_ID"), Required]
		public int RowId { get; set; }

		[Column("NUMBER"), Required]
		public string Number { get; set; }

		[Column("DESCRIPTION"), Required]
		public string Description { get; set; }

		[Column("FORMULA")]
		public string Formula { get; set; }

		[Column("READONLY"), Required]
		public bool IsReadOnly { get; set; }

		[Column("BOLD"), Required]
		public bool IsBold { get; set; }
	}
}
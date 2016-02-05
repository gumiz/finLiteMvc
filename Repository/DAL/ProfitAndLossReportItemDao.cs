using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DAL
{
	[Table("Fin_Reports_ProfitLoss")]
	public class ProfitAndLossReportItemDao
	{
		[Key, Column("ID"), Required]
		public int Id { get; set; }

		[Column("NUMBER"), Required]
		public string Number { get; set; }

		[Column("DESCRIPTION"), Required]
		public string Description { get; set; }

		[Column("FORMULA")]
		public string Formula { get; set; }
	}
}
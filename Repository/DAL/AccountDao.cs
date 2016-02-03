using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DAL
{
	[Table("Fin_Accounts")]
	public class AccountDao
	{
		[Key, Column("NAME"), MaxLength(10), Required]
		public string Name { get; set; }

		[Key, Column("CLIENT_ID"), Required]
		public int ClientId { get; set; }

		[Key, Column("YEAR"), Required]
		public int Year { get; set; }

		[Column("DESCRIPTION")]
		public string Description { get; set; }

		private string CleanName => Name.Replace("-", "");
		public string Synthetic => Name.Substring(0, 3);
		public string Analytic1 => CleanName.Length >= 5 ? Name.Replace("-", "").Substring(3, 2) : "";
		public string Analytic2 => CleanName.Length >= 7 ? Name.Replace("-", "").Substring(5, 2) : "";
	}
}
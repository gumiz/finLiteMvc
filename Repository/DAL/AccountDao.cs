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

		[Column("DESCRIPTION")]
		public string Description { get; set; }

	}
}
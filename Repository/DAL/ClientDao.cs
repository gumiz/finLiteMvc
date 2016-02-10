using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DAL
{
	[Table("Fin_Clients")]
	public class ClientDao
	{
		[Key, Column("ID"), Required]
		public int Id { get; set; }

		[Column("CLIENT_ID"), Required]
		public int ClientId { get; set; }

		[Column("NAME"), Required]
		public string Name { get; set; }

		[Column("DESCRIPTION"), Required]
		public string Description { get; set; }

		[Column("ADDRESS"), Required]
		public string Address { get; set; }
	}
}
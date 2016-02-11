using System;
using Repository.DAL;

namespace Repository.Domain
{
	public class DecodedAccount
	{
		public DecodedAccount()
		{
			Multiplier = 1;
		}
		public string Name { get; set; }
		public Func<DocumentDao, string> Side { get; set; }
		public int Multiplier { get; set; }
	}
}
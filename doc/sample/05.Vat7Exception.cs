using System;

namespace Rekord.Pfk.PortalFb.VatRegistryCore.Exceptions
{
	//ncrunch: no coverage start
	public class Vat7Exception : Exception
	{
		private readonly string _message;
		public override string Message => "VAT-7. " + _message;

		public Vat7Exception(string message) : base(message)
		{
			_message = message;
		}

	}
	//ncrunch: no coverage end
}
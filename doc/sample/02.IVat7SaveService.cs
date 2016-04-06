using Rekord.Pfk.PortalFb.PortalFbCoreBoundary.SessionStaff;
using Rekord.Pfk.PortalFb.VatRegistryBoundary.Domain;

namespace Rekord.Pfk.PortalFb.VatRegistryCoreBoundary.Abstract
{
	public interface IVat7SaveService
	{
		void Save(Session session, Vat7PrintParams vatParams);
		void ChangeState(Session session, Vat7Item item);
	}
}
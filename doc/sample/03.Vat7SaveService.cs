using System;
using System.Linq;
using System.Xml.Linq;
using Rekord.Pfk.PortalFb.PortalFbCoreBoundary.SessionStaff;
using Rekord.Pfk.PortalFb.VatRegistryBoundary.Domain;
using Rekord.Pfk.PortalFb.VatRegistryCore.Exceptions;
using Rekord.Pfk.PortalFb.VatRegistryCoreBoundary.Abstract;
using Rekord.Pfk.PortalFb.VatRegistryCoreBoundary.Abstract.Factories;
using Rekord.Pfk.PortalFb.VatRegistryCoreBoundary.Domain;
using Rekord.ZOS.LiderWSClient.Abstract.DAO;

namespace Rekord.Pfk.PortalFb.VatRegistryCore.DictionaryStaff.Vat7
{
	public class Vat7SaveService : IVat7SaveService
	{
		private Session _session;
		private IDAO<Vat7Dao> _crud;
		private Vat7Dao _item;
		private readonly IVatObjectFactory _vatObjectFactory;
		private int _version = 1;
		private Vat7Data _vat7Data;
		private XDocument _xml;
		private Vat7PrintParams _vatParams;
		private Vat7Item _vat7Item;

		public Vat7SaveService(IVatObjectFactory vatObjectFactory)
		{
			_vatObjectFactory = vatObjectFactory;
		}

		public void Save(Session session, Vat7PrintParams vatParams)
		{
			_session = session;
			_vatParams = vatParams;

			ValidateParams();
			GetVersionNumber();
			GetVat7Data();
			UpdateVat7DataBudgetParams();
			UpdateVat7DataPrintParams();
			VatVariantUpdata();
			ConvertVat7DataToXml();
			CreateItem();
			CreateCrud();
			SaveUsingCrud();
		}

		public void ChangeState(Session session, Vat7Item item)
		{
			_session = session;
			_vat7Item = item;

			CreateItemBasedOnVat7();
			CreateCrud();
			SaveUsingCrud();
		}

		private void CreateItemBasedOnVat7()
		{
			var item = _vatObjectFactory.GetVat7ReaderService().GetById(_session, _vat7Item.Id);

			_item = new Vat7Dao() { Id = item.Id, State = 1, Year = item.Year, Month = item.Month, Version = item.Version, Date = item.Date, IsActual = item.IsActual };
		}

		private void VatVariantUpdata()
		{
			_vat7Data.WariantFormularza = "16";
		}

		private void UpdateVat7DataPrintParams()
		{
			_vat7Data.Year = _vatParams.Year;
			_vat7Data.Month = _vatParams.Month;
			_vat7Data.CelZlozenia = _vatParams.CelZlozenia;
			_vat7Data.P73 = DateTime.Now.ToString("yyyy-MM-dd");
		}


		private void UpdateVat7DataBudgetParams()
		{
			var budgetParams = _vatObjectFactory.ObjectFactory.GetBudzetParametersCollectionGetter().GetParameters(_session);
			_vat7Data.PelnaNazwa = budgetParams.NazwaUrzedu;
			_vat7Data.NIP = budgetParams.Nip;
			_vat7Data.REGON = budgetParams.Regon;
			_vat7Data.KodUrzedu = budgetParams.KodUrzeduDlaSystemuEDeklaracje;
		}

		private void GetVat7Data()
		{
			_vat7Data = _vatObjectFactory.GetVat7DataService().Get(_session, _vatParams.Year, _vatParams.Month);
		}

		private void ConvertVat7DataToXml()
		{
			var serializer = _vatObjectFactory.ObjectFactory.GetXmlSerializer<Vat7Data>();
			_xml = serializer.Serialize(_vat7Data);
		}

		private void GetVersionNumber()
		{
			var versions = _vatObjectFactory.GetVat7DictionaryProvider().GetVersions(_session, _vatParams.Year, _vatParams.Month);
			if ((versions != null) && (versions.Count != 0))
				_version = versions.Max(x => x.Version) + 1;
		}

		private void CreateItem()
		{
			_item = new Vat7Dao { Year = _vatParams.Year, Month = _vatParams.Month, Date = DateTime.Now, Version = _version, Xml = _xml.ToString() };
		}

		private void ValidateParams()
		{
			if ((_vatParams.Year == 0) && (_vatParams.Month == 0))
				throw new Vat7Exception("Niepoprawne parametry (rok/miesiac).");
		}

		private void SaveUsingCrud()
		{
			_crud.Save(_item);
		}

		private void CreateCrud()
		{
			var crudCreator = _vatObjectFactory.ObjectFactory.GetLiderWsCrudCreator();
			_crud = crudCreator.GetCrud<Vat7Dao>(_session);
		}

	}
}
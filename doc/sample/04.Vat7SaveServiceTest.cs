using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using NSubstitute;
using Rekord.Pfk.PortalFb.PortalFbCoreBoundary.Abstract.Factories;
using Rekord.Pfk.PortalFb.PortalFbCoreBoundary.Domain.ParametersStaff;
using Rekord.Pfk.PortalFb.PortalFbCoreBoundary.SessionStaff;
using Rekord.Pfk.PortalFb.VatRegistryBoundary.Domain;
using Rekord.Pfk.PortalFb.VatRegistryCore.DictionaryStaff.Vat7;
using Rekord.Pfk.PortalFb.VatRegistryCore.Exceptions;
using Rekord.Pfk.PortalFb.VatRegistryCoreBoundary.Abstract.Factories;
using Rekord.Pfk.PortalFb.VatRegistryCoreBoundary.Domain;
using Xunit;

namespace Rekord.Pfk.PortalFb.VatRegistryCoreTests.DictionariesStaff.Vat7
{
	public class Vat7SaveServiceTest
	{
		private readonly Session _session;
		private readonly Vat7SaveService _service;
		private readonly IObjectFactory _objectFactory;
		private readonly IVatObjectFactory _vatObjectFactory;
		private readonly IList<Vat7Dao> _versions;
		private readonly Vat7Data _vat7Data;
		private readonly XDocument _xml;
		private readonly BudzetParametersCollection _budgetParams;
		private readonly Vat7PrintParams _vatParams;

		public Vat7SaveServiceTest()
		{
			_budgetParams = new BudzetParametersCollection { NazwaUrzedu = "Test123", Regon = "1231341", Nip = "5353123" };
			_vatParams = new Vat7PrintParams {Year = 2016, Month = 3, CelZlozenia = "2", KodUrzedu = "ee"};
			_xml = XDocument.Parse("<vat7><rok>2099</rok></vat7>");
			_vat7Data = new Vat7Data {P01 = 100.00, P02 = 200.00};
			_versions = new List<Vat7Dao> {new Vat7Dao {Version = 1}, new Vat7Dao { Version = 3 } };
			_session = new Session();
			_objectFactory = Substitute.For<IObjectFactory>();
			_vatObjectFactory = Substitute.For<IVatObjectFactory>();
			_vatObjectFactory.ObjectFactory.Returns(_objectFactory);
			_service = new Vat7SaveService(_vatObjectFactory);
			_vatObjectFactory.GetVat7DictionaryProvider().GetVersions(_session, _vatParams.Year, _vatParams.Month).Returns(_versions);
			_vatObjectFactory.GetVat7DataService().Get(_session, _vatParams.Year, _vatParams.Month).Returns(_vat7Data);
			_objectFactory.GetXmlSerializer<Vat7Data>().Serialize(_vat7Data).Returns(_xml);
			_objectFactory.GetBudzetParametersCollectionGetter().GetParameters(_session).Returns(_budgetParams);
		}

		private void Save()
		{
			_service.Save(_session, _vatParams);
		}

		[Fact]
		public void Save_ValidatesParams()
		{
			_vatParams.Year = 0;
			_vatParams.Month = 0;
			
			var error = Assert.Throws<Vat7Exception>(() => _service.Save(_session, _vatParams));
			
			Assert.Equal("VAT-7. Niepoprawne parametry (rok/miesiac).", error.Message);
		}

		[Fact]
		public void Save_GetsVersionNumber()
		{
			Save();
			
			_vatObjectFactory.GetVat7DictionaryProvider().Received().GetVersions(_session, _vatParams.Year, _vatParams.Month);
		}

		[Fact]
		public void Save_WhenNullPreviousVersions_SetsVersion1()
		{
			AssertVersionsNumber(null);
		}

		[Fact]
		public void Save_When0PreviousVersions_SetsVersion1()
		{
			AssertVersionsNumber(new List<Vat7Dao>());
		}

		[Fact]
		public void Save_ShouldGetVat7Data()
		{
			Save();
			
			_vatObjectFactory.GetVat7DataService().Received().Get(_session, _vatParams.Year, _vatParams.Month);
		}

		[Fact]
		public void Save_ShouldConvertToXml()
		{
			Save();
			
			_objectFactory.GetXmlSerializer<Vat7Data>().Received().Serialize(_vat7Data);
		}
		
		[Fact]
		public void Save_ShouldUpdatePrintParams()
		{
			Vat7Data item = null;
			_vatObjectFactory.ObjectFactory.GetXmlSerializer<Vat7Data>().Serialize(Arg.Do<Vat7Data>(x => item = x));
			
			Save();
			
			_objectFactory.GetBudzetParametersCollectionGetter().Received().GetParameters(_session);
			Assert.Equal(_vatParams.CelZlozenia, item.CelZlozenia);
			Assert.Equal(_vatParams.Year, item.Year);
			Assert.Equal(_vatParams.Month, item.Month);
			Assert.Equal("", item.P71);
			Assert.Equal(DateTime.Now.ToString("yyyy-MM-dd"), item.P73);
		}

		[Fact]
		public void Save_ShouldUpdateBudgetParams()
		{
			Vat7Data item = null;
			_vatObjectFactory.ObjectFactory.GetXmlSerializer<Vat7Data>().Serialize(Arg.Do<Vat7Data>(x => item = x));
			
			Save();
			
			_objectFactory.GetBudzetParametersCollectionGetter().Received().GetParameters(_session);
			Assert.Equal(_budgetParams.NazwaUrzedu, item.PelnaNazwa);
			Assert.Equal(_budgetParams.Nip, item.NIP);
			Assert.Equal(_budgetParams.Regon, item.REGON);
			Assert.Equal(_budgetParams.KodUrzeduDlaSystemuEDeklaracje, item.KodUrzedu);
			Assert.Equal("", item.P69);
			Assert.Equal("", item.P70);
			Assert.Equal("", item.P72);
		}

		[Fact]
		public void Save_WariantShouldBeSetTo16()
		{
			Vat7Data item = null;
			_vatObjectFactory.ObjectFactory.GetXmlSerializer<Vat7Data>().Serialize(Arg.Do<Vat7Data>(x => item = x));
			
			Save();
			
			Assert.Equal("16", item.WariantFormularza);
		}
		
		[Fact]
		public void Save_ShouldCreateCrud()
		{
			Save();
			
			_objectFactory.GetLiderWsCrudCreator().Received().GetCrud<Vat7Dao>(_session);
		}

		[Fact]
		public void Save_SavesItem()
		{
			Vat7Dao item = null;
			_objectFactory.GetLiderWsCrudCreator().GetCrud<Vat7Dao>(_session).Save(Arg.Do<Vat7Dao>(x=>item=x));
			
			Save();
			
			Assert.Equal(_vatParams.Year, item.Year);
			Assert.Equal(_vatParams.Month, item.Month);
			AssertDate(item);
			Assert.Equal(4, item.Version);
			Assert.Equal(_xml.ToString(), item.Xml);
		}

		private void AssertVersionsNumber(IList<Vat7Dao> versions)
		{
			_vatObjectFactory.GetVat7DictionaryProvider().GetVersions(_session, _vatParams.Year, _vatParams.Month).Returns(versions);
			Vat7Dao item = null;
			_objectFactory.GetLiderWsCrudCreator().GetCrud<Vat7Dao>(_session).Save(Arg.Do<Vat7Dao>(x => item = x));
			Save();
			Assert.Equal(1, item.Version);
		}

		private static void AssertDate(Vat7Dao item)
		{
			Assert.Equal(DateTime.Now.Year, item.Date.Year);
			Assert.Equal(DateTime.Now.Month, item.Date.Month);
			Assert.Equal(DateTime.Now.Day, item.Date.Day);
			Assert.Equal(DateTime.Now.Hour, item.Date.Hour);
			Assert.Equal(DateTime.Now.Minute, item.Date.Minute);
		}

	}
}

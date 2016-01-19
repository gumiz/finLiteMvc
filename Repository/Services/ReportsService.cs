using System.Collections.Generic;
using System.Linq;
using Repository.Abstract;
using Repository.DAL;
using Repository.Domain;

namespace Repository.Services
{
	public class ReportsService : IReportsService
	{
		private readonly DefaultContext _dbContext;
		private List<Report> _result;
		private List<AccountDao> _accounts;
		private int _year;
		private int _clientId;
		private List<DocumentDao> _documentsCt;
		private Report _report;
		private List<DocumentDao> _documentsDt;

		public ReportsService(DefaultContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<Report> GetReports(int year, int clientId)
		{
			_year = year;
			_clientId = clientId;

			PrepareReport();
			GetAccounts();

			foreach (var account in _accounts)
			{
				_report = new Report { AccountName = account.Name, Dt = new List<ReportDocument>(), Ct = new List<ReportDocument>() };

				//ct
				_documentsCt = _dbContext.Documents.Where( c => c.ClientId.Equals(_clientId) && c.Year.Equals(_year) && c.AccountCt.Equals(account.Name)).ToList();
				foreach (var ct in _documentsCt)
					_report.Ct.Add(new ReportDocument {Id = ct.Id, AutoNumber = ct.AutoNumber, Number = ct.Number, Price = ct.Price});

				//dt
				_documentsDt = _dbContext.Documents.Where(c => c.ClientId.Equals(_clientId) && c.Year.Equals(_year) && c.AccountDt.Equals(account.Name)).ToList();
				foreach (var dt in _documentsDt)
					_report.Dt.Add(new ReportDocument { Id = dt.Id, AutoNumber = dt.AutoNumber, Number = dt.Number, Price = dt.Price });

				if (_documentsCt.Count != 0 || _documentsDt.Count != 0)
					_result.Add(_report);
			}

			return _result;
		}

		private void GetAccounts()
		{
			_accounts = _dbContext.Accounts.Where(c => c.ClientId.Equals(_clientId)).OrderBy(c => c.Name).ToList();
		}

		private void PrepareReport()
		{
			_result = new List<Report>();
		}

//		public void TestData()
//		{
//			var test = [
//			{
//				"accountName": "100",
//				"items":
//				{
//					"dt":[
//					{
//						"id": 3,
//						"number": "WB 004/2015",
//						"price": "500"
//					}
//					,
//					{
//						"id": 7,
//						"number": "WB 007/2015",
//						"price": "500"
//					}
//					],
//					"ct":[
//					{
//						"id":
//						16,
//						"number":
//						"UD 1/2015",
//						"price":
//						"300"
//					}
//				,
//					{
//						"id":
//						17,
//						"number":
//						"UD 2/2015",
//						"price":
//						"1200"
//					}]
//				}
//			}
//		,
//			{
//				"accountName":
//				"201",
//				"items":
//				{
//					"dt":[
//					{
//						"id":
//						4,
//						"number":
//						"WB 004/2015",
//						"price":
//						"300"
//					}
//				,
//					{
//						"id":
//						10,
//						"number":
//						"WB 010/2015",
//						"price":
//						"700"
//					}
//				,
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						0
//					}
//				],
//					"ct":[
//					{
//						"id":
//						20,
//						"number":
//						"ZA 1/2015",
//						"price":
//						"300"
//					}
//				,
//					{
//						"id":
//						23,
//						"number":
//						"ZA 4/2015",
//						"price":
//						"300"
//					}
//				,
//					{
//						"id":
//						24,
//						"number":
//						"ZA 5/2015",
//						"price":
//						"400"
//					}
//				,
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						5.22
//					}
//				]
//				}
//			}
//		,
//			{
//				"accountName":
//				"500",
//				"items":
//				{
//					"dt":[
//					{
//						"id":
//						16,
//						"number":
//						"UD 1/2015",
//						"price":
//						"300"
//					}
//				,
//					{
//						"id":
//						20,
//						"number":
//						"ZA 1/2015",
//						"price":
//						"300"
//					}
//				,
//					{
//						"id":
//						21,
//						"number":
//						"ZA 2/2015",
//						"price":
//						"125.88"
//					}
//				,
//					{
//						"id":
//						22,
//						"number":
//						"ZA 3/2015",
//						"price":
//						"188.39"
//					}
//				,
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						0
//					}
//				],
//					"ct":[
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						0
//					}
//				]
//				}
//			}
//		,
//			{
//				"accountName":
//				"501",
//				"items":
//				{
//					"dt":[
//					{
//						"id":
//						17,
//						"number":
//						"UD 2/2015",
//						"price":
//						"1200"
//					}
//				,
//					{
//						"id":
//						24,
//						"number":
//						"ZA 5/2015",
//						"price":
//						"400"
//					}
//				,
//					{
//						"id":
//						27,
//						"number":
//						"ZA 8/2015",
//						"price":
//						"146.80"
//					}
//				,
//					{
//						"id":
//						28,
//						"number":
//						"ZA 9/2015",
//						"price":
//						"198.72"
//					}
//				,
//					{
//						"id":
//						29,
//						"number":
//						"ZA 10/2015",
//						"price":
//						"26.61"
//					}
//				,
//					{
//						"id":
//						30,
//						"number":
//						"ZA 11/2015",
//						"price":
//						"500"
//					}
//				,
//					{
//						"id":
//						31,
//						"number":
//						"ZA 12/2015",
//						"price":
//						"130.94"
//					}
//				,
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						0
//					}
//				],
//					"ct":[
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						0
//					}
//				]
//				}
//			}
//		,
//			{
//				"accountName":
//				"502",
//				"items":
//				{
//					"dt":[
//					{
//						"id":
//						18,
//						"number":
//						"UD 3/2015",
//						"price":
//						"270"
//					}
//				,
//					{
//						"id":
//						19,
//						"number":
//						"UD 4/2015",
//						"price":
//						"600"
//					}
//				,
//					{
//						"id":
//						23,
//						"number":
//						"ZA 4/2015",
//						"price":
//						"300"
//					}
//				,
//					{
//						"id":
//						25,
//						"number":
//						"ZA 6/2015",
//						"price":
//						"199.75"
//					}
//				,
//					{
//						"id":
//						26,
//						"number":
//						"ZA 7/2015",
//						"price":
//						"131.82"
//					}
//				,
//					{
//						"id":
//						32,
//						"number":
//						"ZA 13/2015",
//						"price":
//						"122"
//					}
//				,
//					{
//						"id":
//						33,
//						"number":
//						"ZA 14/2015",
//						"price":
//						"99.45"
//					}
//				,
//					{
//						"id":
//						34,
//						"number":
//						"ZA 15/2015",
//						"price":
//						"80.20"
//					}
//				,
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						0
//					}
//				],
//					"ct":[
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						0
//					}
//				]
//				}
//			}
//		,
//			{
//				"accountName":
//				"550",
//				"items":
//				{
//					"dt":[
//					{
//						"id":
//						5,
//						"number":
//						"WB 005/2015",
//						"price":
//						"3"
//					}
//				,
//					{
//						"id":
//						11,
//						"number":
//						"WB 011/2015",
//						"price":
//						"3"
//					}
//				,
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						0
//					}
//				],
//					"ct":[
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						0
//					}
//				]
//				}
//			}
//		,
//			{
//				"accountName":
//				"700-1",
//				"items":
//				{
//					"dt":[
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						0
//					}
//				],
//					"ct":[
//					{
//						"id":
//						1,
//						"number":
//						"WB 002/2015",
//						"price":
//						"1350"
//					}
//				,
//					{
//						"id":
//						2,
//						"number":
//						"WB 003/2015",
//						"price":
//						"1500"
//					}
//				,
//					{
//						"id":
//						6,
//						"number":
//						"WB 006/2015",
//						"price":
//						"350"
//					}
//				,
//					{
//						"id":
//						9,
//						"number":
//						"WB 009/2015",
//						"price":
//						"1000"
//					}
//				,
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						0
//					}
//				]
//				}
//			}
//		,
//			{
//				"accountName":
//				"130-1",
//				"items":
//				{
//					"dt":[
//					{
//						"id":
//						1,
//						"number":
//						"WB 002/2015",
//						"price":
//						"1350"
//					}
//				,
//					{
//						"id":
//						2,
//						"number":
//						"WB 003/2015",
//						"price":
//						"1500"
//					}
//				,
//					{
//						"id":
//						6,
//						"number":
//						"WB 006/2015",
//						"price":
//						"350"
//					}
//				,
//					{
//						"id":
//						9,
//						"number":
//						"WB 009/2015",
//						"price":
//						"1000"
//					}
//				,
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						1592.89
//					}
//				],
//					"ct":[
//					{
//						"id":
//						3,
//						"number":
//						"WB 004/2015",
//						"price":
//						"500"
//					}
//				,
//					{
//						"id":
//						4,
//						"number":
//						"WB 004/2015",
//						"price":
//						"300"
//					}
//				,
//					{
//						"id":
//						5,
//						"number":
//						"WB 005/2015",
//						"price":
//						"3"
//					}
//				,
//					{
//						"id":
//						7,
//						"number":
//						"WB 007/2015",
//						"price":
//						"500"
//					}
//				,
//					{
//						"id":
//						8,
//						"number":
//						"WB 008/2015",
//						"price":
//						"500"
//					}
//				,
//					{
//						"id":
//						10,
//						"number":
//						"WB 010/2015",
//						"price":
//						"700"
//					}
//				,
//					{
//						"id":
//						11,
//						"number":
//						"WB 011/2015",
//						"price":
//						"3"
//					}
//				,
//					{
//						"id":
//						12,
//						"number":
//						"WB 012/2015",
//						"price":
//						"500"
//					}
//				,
//					{
//						"id":
//						13,
//						"number":
//						"WB 013/2015",
//						"price":
//						"500"
//					}
//				,
//					{
//						"id":
//						14,
//						"number":
//						"WB 014/2015",
//						"price":
//						"500"
//					}
//				,
//					{
//						"id":
//						15,
//						"number":
//						"WB 015/2015",
//						"price":
//						"500"
//					}
//				,
//					{
//						"id":
//						0,
//						"number":
//						"BO",
//						"price":
//						0
//					}
//				]
//				}
//			}
//		]
//		}
	}
}
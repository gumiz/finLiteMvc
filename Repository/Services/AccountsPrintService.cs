namespace Repository.Services
{
	public class AccountsPrintService : AbstractPrintService
	{
		public AccountsPrintService(Factory factory) : base(factory)
		{
		}

		protected override void GetRows()
		{
			Rows = "";
			var accounts = Factory.GetAccoutnsService().GetAccounts(ClientdId, Year);
			foreach (var ac in accounts)
				Rows += $"<tr><td class=\"col-4\">{ac.Name}</td><td class=\"col-8\">{ac.Description}</td></td></tr>";
		}

		protected override void GetHeaderRow()
		{
			HeaderRow = "<tr><th class=\"col-4\">Numer</th><th class=\"col-8\">Nazwa</th></tr>";
		}

		protected override void GetTitle()
		{
			Title = $"Plan kont na rok {Year}";
		}

		protected override void GetTableClass()
		{
			TableClass = "col-6";
		}

	}
}
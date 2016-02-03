namespace Repository.Domain
{
	public class Account
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Year { get; set; }
		public int ClientId { get; set; }
		private string CleanName => Name.Replace("-", "");
		public string Synthetic => Name.Substring(0, 3);
		public string Analytic1 => CleanName.Length >= 5 ? Name.Replace("-", "").Substring(3, 2) : "";
		public string Analytic2 => CleanName.Length >= 7 ? Name.Replace("-", "").Substring(5, 2) : "";
	}
}

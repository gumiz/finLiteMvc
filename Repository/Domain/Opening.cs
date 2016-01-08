namespace Repository.Domain
{
	public class Opening
	{
		public int Id { get; set; }
		public int ClientId { get; set; }
		public int Year { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double Ct { get; set; }
		public double Dt { get; set; }
	}
}
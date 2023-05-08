namespace Club_Reservations.Models
{
	public class Table
	{
		public int Id { get; set; }
		public int Capacity { get; set; }
		public bool SmokingAllowed { get; set; }
        public double DurationInHours { get; internal set; }
    }
}

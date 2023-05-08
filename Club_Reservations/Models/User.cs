using System.ComponentModel.DataAnnotations;

namespace Club_Reservations.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public virtual List<Reservation> Reservations { get; set; }

        public User()
        {
            Reservations = new List<Reservation>();
        }
    }
}

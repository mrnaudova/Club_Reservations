namespace Club_Reservations.Models
{
	public class Reservation
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int TableId { get; set; }
        public virtual Table? Table { get; set; }
        public string? Description { get; set; }

        // метод, който проверява за конфликти между резервациите
    public bool IsConflictWith(Reservation otherReservation)
    {
        if (this.Table != otherReservation.Table) // ако резервациите са за различни маси, няма конфликт
            return false;

        if (this.User == otherReservation.User) // ако резервациите са на един и същи потребител, няма конфликт
            return false;

        DateTime start1 = this.ReservationDateTime;
        DateTime end1 = start1.AddHours(this.Table.DurationInHours); // изчисляваме края на първата резервация

        DateTime start2 = otherReservation.ReservationDateTime;
        DateTime end2 = start2.AddHours(otherReservation.Table.DurationInHours); // изчисляваме края на втората резервация

        // ако интервалите на резервациите се припокриват, има конфликт
        if (start1 < end2 && start2 < end1)
            return true;

        return false; // няма конфликт
    }
    }

    
}

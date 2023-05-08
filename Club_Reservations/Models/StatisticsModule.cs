using System.ComponentModel.DataAnnotations;

namespace Club_Reservations.Models
{
    public class StatisticsModule
    {
        [Key]
        public int Id{ get; set; }
        public int NumberOfTables { get; set; }
        public int NumberOfCustomers { get; set; }
        public int NumberOfPastReservations { get; set; }
        public int NumberOfUpcomingReservations { get; set; }

        public StatisticsModule()
        {
            // Инициализиране на статистическите данни
            NumberOfTables = 0;
            NumberOfCustomers = 0;
            NumberOfPastReservations = 0;
            NumberOfUpcomingReservations = 0;
        }

        public void UpdateStatistics(List<Reservation> reservations)
        {
            // Изчисляване на статистиките базирано на списъка с резервации
            NumberOfTables = reservations.Select(r => r.Table).Distinct().Count();
            NumberOfCustomers = reservations.Select(r => r.User).Distinct().Count();
            NumberOfPastReservations = reservations.Count(r => r.ReservationDateTime < DateTime.Now);
            NumberOfUpcomingReservations = reservations.Count(r => r.ReservationDateTime >= DateTime.Now);
        }
    }

}

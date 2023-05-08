using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Club_Reservations.Models;

namespace Club_Reservations.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Club_Reservations.Models.User>? User { get; set; }
		public DbSet<Club_Reservations.Models.Table>? Table { get; set; }
		public DbSet<Club_Reservations.Models.Reservation>? Reservation { get; set; }
		public DbSet<Club_Reservations.Models.StatisticsModule>? StatisticsModule { get; set; }
	}
}
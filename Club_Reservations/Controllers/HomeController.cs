using Club_Reservations.Data;
using Club_Reservations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Club_Reservations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; //

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context) //
        {
            _logger = logger;
            _context = context; //
        }

        public IActionResult Index()
        {
            ViewData["TablesCount"] = _context.Table.Count();
            ViewData["ClientsCount"] = _context.User.Count();
            ViewData["ReservationCount"] = _context.Reservation.Count();
           // ViewData["ClientsCount"] = _context.Users.Count();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
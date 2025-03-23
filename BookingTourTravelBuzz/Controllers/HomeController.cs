using System.Diagnostics;
using BookingTourTravelBuzz.Data;
using BookingTourTravelBuzz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingTourTravelBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // Đảm bảo khai báo đúng DbContext


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult About()

        //[Authorize]
        //public IActionResult Privacy()

        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Search()
        {
            var destinations = _context.TOURS
                                       .Where(t => !string.IsNullOrEmpty(t.DESTINATION_TOUR)) // Tránh null hoặc rỗng
                                       .Select(t => t.DESTINATION_TOUR)
                                       .Distinct()
                                       .ToList();

            ViewData["Destinations"] = destinations;
            return View();
        }
    }
}

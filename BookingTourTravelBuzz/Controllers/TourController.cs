using BookingTourTravelBuzz.Models.Tours; // Đảm bảo import đúng namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingTourTravelBuzz.Controllers
{
    public class TourController : Controller
    {
        private readonly Models.Tours.ITourRepository _toursRepository;

        public TourController(Models.Tours.ITourRepository toursRepository)
        {
            _toursRepository = toursRepository;
        }

        public IActionResult Domestic(int? idArea)
        {
            var tours = _toursRepository.GetAllDomesticTours();

            if (idArea.HasValue)
            {
                tours = tours.Where(t => t.ID_AREA == idArea.Value).ToList();
            }

            return View(tours);
        }

        public IActionResult International(int? idArea)
        {
            var tours = _toursRepository.GetAllInternationalTours();

            if (idArea.HasValue)
            {
                tours = tours.Where(t => t.ID_AREA == idArea.Value).ToList();
            }

            return View(tours);
        }


        public IActionResult TourDetails(int id)
        {
            var tour = _toursRepository.GetTourById(id);
            if (tour == null)
            {
                return NotFound();
            }
            return View(tour);
        }

    }
}

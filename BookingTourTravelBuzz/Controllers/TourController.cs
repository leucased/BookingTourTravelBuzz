using BookingTourTravelBuzz.Models.Tours; // Đảm bảo import đúng namespace
using Microsoft.AspNetCore.Mvc;

namespace BookingTourTravelBuzz.Controllers
{
    public class TourController : Controller
    {
        private readonly Models.Tours.ITourRepository _toursRepository;

        public TourController(Models.Tours.ITourRepository toursRepository)
        {
            _toursRepository = toursRepository;
        }

        public IActionResult Domestic()
        {
            var tours = _toursRepository.GetAllDomesticTours();
            return View(tours);
        }

        public IActionResult International()
        {
            var tours = _toursRepository.GetAllInternationalTours();
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

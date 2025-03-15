using BookingTourTravelBuzz.Data;
using BookingTourTravelBuzz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookingTourTravelBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class TourManager : Controller
    {

        private readonly Models.Tours.ITourRepository _toursRepository;

        public TourManager(Models.Tours.ITourRepository toursRepository)
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

        public IActionResult Create()
        {
            var tours = _toursRepository.GetAllDomesticTours();
            ViewBag.tours = new SelectList(tours, "ID_TOUR", "NAME_TOUR");

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

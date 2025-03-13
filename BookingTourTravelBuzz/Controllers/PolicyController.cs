using Microsoft.AspNetCore.Mvc;

namespace BookingTourTravelBuzz.Controllers
{
    public class PolicyController : Controller
    {
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
        public IActionResult TourTerms()
        {
            return View();
        }
        public IActionResult Cancellation()
        {
            return View();
        }

    }
}

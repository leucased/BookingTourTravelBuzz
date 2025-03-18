using Microsoft.AspNetCore.Mvc;

namespace BookingTourTravelBuzz.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerController : Controller
    {
        public IActionResult Profile()
        {
            return View(); // Mặc định tìm trong Views/Customer/Profile.cshtml
        }
    }
}

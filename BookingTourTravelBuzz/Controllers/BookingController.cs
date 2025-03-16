using BookingTourTravelBuzz.Data;
using BookingTourTravelBuzz.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingTourTravelBuzz.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Xử lý lưu booking
        [HttpPost]
        public IActionResult BookTour(Booking model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Thêm booking vào database
                    _context.BOOKINGS.Add(model);
                    _context.SaveChanges();

                    // Chuyển hướng đến trang xác nhận đặt tour
                    return RedirectToAction("BookingConfirmation", new { id = model.ID_BOOKING });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra: " + ex.Message);
                }
            }
            return View(model);
        }

        // Trang xác nhận đặt tour
        public IActionResult BookingConfirmation(int id)
        {
            var booking = _context.BOOKINGS.FirstOrDefault(b => b.ID_BOOKING == id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }
    }
}

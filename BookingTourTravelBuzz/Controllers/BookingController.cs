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
                    return RedirectToAction("Checkout", new { id = model.ID_BOOKING });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra: " + ex.Message);
                }
            }
            return View(model);
        }

        // Trang hiển thị form thanh toán tiền cọc
        public IActionResult Checkout(int id)
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

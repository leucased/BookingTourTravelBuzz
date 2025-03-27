using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookingTourTravelBuzz.Data;
using BookingTourTravelBuzz.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace BookingTourTravelBuzz.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Booking(Booking model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                Console.WriteLine("ModelState Errors: " + string.Join(", ", errors));
                return View("Error", new ErrorViewModel { Message = "Dữ liệu nhập không hợp lệ." });
            }

            // Lấy ID khách hàng từ User.Identity
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return View("Error", new ErrorViewModel { Message = "Bạn cần đăng nhập để đặt tour." });
            }

            // Kiểm tra tour có tồn tại không
            var tour = _context.TOURS.FirstOrDefault(t => t.ID_TOUR == model.ID_TOUR);
            if (tour == null)
            {
                return View("Error", new ErrorViewModel { Message = "Tour không tồn tại." });
            }

            // Tạo đối tượng booking mới
            var newBooking = new Booking
            {
                ID_TOUR = model.ID_TOUR,
                Id = userId, // ID khách hàng đã đăng nhập
                Tour = tour,
                START_DATES = model.START_DATES,
                FULLNAME_CUSTOMER = model.FULLNAME_CUSTOMER,
                PHONE_CUSTOMER = model.PHONE_CUSTOMER,
                EMAIL_CUSTOMER = model.EMAIL_CUSTOMER,
                ID_GUIDE = model.ID_GUIDE,
                QUANTITY_BOOKING = model.QUANTITY_BOOKING,
                TOTAL_PRICE = model.TOTAL_PRICE,
                BOOKING_DATE = DateTime.Now, // Ngày đặt tour
                STATUS_BOOKING = "Chưa thanh toán" // Mặc định là chưa thanh toán
            };

            // Lưu vào database
            try
            {
                _context.BOOKINGS.Add(newBooking);
                _context.SaveChanges();
                return RedirectToAction("Checkout", new { id = newBooking.ID_BOOKING });
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { Message = "Lỗi lưu vào database: " + ex.Message });
            }
        }

        public IActionResult Checkout(int id)
        {
            var booking = _context.BOOKINGS
                .Include(b => b.Tour)
                .Include(b => b.Customer)
                .FirstOrDefault(b => b.ID_BOOKING == id);

            if (booking == null || booking.Tour == null || booking.Customer == null)
            {
                return View("Error", new ErrorViewModel { Message = "Dữ liệu không hợp lệ hoặc bị thiếu." });
            }
            return View(booking);
        }
    }
}

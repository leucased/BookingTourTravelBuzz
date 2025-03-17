using BookingTourTravelBuzz.Data;
using Microsoft.AspNetCore.Mvc;
using BookingTourTravelBuzz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BookingTourTravelBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TourController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TourController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View(new Tour()); // 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tour tour)  // Đảm bảo có đầy đủ namespace
        {
            if (ModelState.IsValid)
            {
                _context.TOURS.Add(tour);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tour);
        }

        // Action hiển thị form chỉnh sửa
        public async Task<IActionResult> Edit(int id)
        {
            var tour = _context.TOURS.Find(id);
            if (tour == null)
            {
                return NotFound();
            }

            // Lấy danh sách khu vực từ database và đổ vào ViewBag
            ViewBag.Areas = _context.AREAS.ToList();

            return View(tour);
        }

        // Action xử lý dữ liệu sau khi sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tour tour)
        {
            if (id != tour.ID_TOUR) // Kiểm tra ID hợp lệ
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tour);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Cập nhật Tour thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.TOURS.Any(e => e.ID_TOUR == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // Quay về danh sách Tour
            }
            return View(tour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var tour = _context.TOURS.Find(id);
            if (tour == null)
            {
                return NotFound();
            }

            _context.TOURS.Remove(tour);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

using BookingTourTravelBuzz.Data;
using Microsoft.AspNetCore.Mvc;
using BookingTourTravelBuzz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult Edit(int id)
        {
            var tour = _context.TOURS.Include(t => t.Area).FirstOrDefault(t => t.ID_TOUR == id);
            if (tour == null)
            {
                return NotFound();
            }

            // Lấy danh sách khu vực để tạo dropdown
            ViewBag.AreaList = new SelectList(_context.AREAS, "ID_AREA", "NAME_AREA", tour.ID_AREA);

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

        public IActionResult Delete(int? id)
        {
            var tour = _context.TOURS.Find(id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);  // Truyền đối tượng tour tìm được vào view
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

            return RedirectToAction("Domestic");  // Chuyển hướng sau khi xóa thành công
        }

    }
}

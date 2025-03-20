using BookingTourTravelBuzz.Models.Guides;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingTourTravelBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideRepostory _guideRepository;

        public GuideController(IGuideRepostory guideRepository)
        {
            _guideRepository = guideRepository;
        }

        // GET: Guide
        public IActionResult ListGuides()
        {
            var guides = _guideRepository.GetAll();
            return View(guides);
        }

        // GET: Guide/Details/5
        public IActionResult Details(int id)
        {
            var guide = _guideRepository.GetById(id);
            if (guide == null) return NotFound();
            return View(guide);
        }

        // GET: Guide/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guide/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Guide guide)
        {
            if (ModelState.IsValid)
            {
                _guideRepository.Create(guide);
                return RedirectToAction("ListGuides", "Guide");
            }
            return View(guide);
        }

        // GET: Guide/Edit/5
        public IActionResult Edit(int id)
        {
            var guide = _guideRepository.GetById(id);
            if (guide == null) return NotFound();
            return View(guide);
        }

        // POST: Guide/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guide guide)
        {
            if (ModelState.IsValid)
            {
                _guideRepository.Edit(guide);
                return RedirectToAction("ListGuides", "Guide");
            }
            return View(guide);
        }

        // GET: Guide/Delete/5
        public IActionResult Delete(int id)
        {
            var guide = _guideRepository.GetById(id);
            if (guide == null) return NotFound();
            return View(guide);
        }

        // POST: Guide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _guideRepository.Delete(id);
            return RedirectToAction("ListGuides", "Guide");
        }
    }
}

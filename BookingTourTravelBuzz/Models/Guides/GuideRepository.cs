using System.Collections.Generic;
using System.Linq;
using BookingTourTravelBuzz.Data; // Thay YourNamespace bằng namespace của bạn
using BookingTourTravelBuzz.Models;

namespace BookingTourTravelBuzz.Models.Guides
{
    public class GuideRepository : IGuideRepostory
    {
        private readonly ApplicationDbContext _context;

        public GuideRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Guide> GetAll()
        {
            return _context.GUIDES.ToList();
        }

        public Guide? GetById(int id)
        {
            return _context.GUIDES.Find(id);
        }

        public void Create(Guide guide)
        {
            _context.GUIDES.Add(guide);
            _context.SaveChanges();
        }

        public void Edit(Guide guide)
        {
            _context.GUIDES.Update(guide);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var guide = _context.GUIDES.Find(id);
            if (guide != null)
            {
                _context.GUIDES.Remove(guide);
                _context.SaveChanges();
            }
        }
    }
}

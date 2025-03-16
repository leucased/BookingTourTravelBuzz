using System.Collections.Generic;
using System.Linq;
using BookingTourTravelBuzz.Data; // Namespace của DbContext
using BookingTourTravelBuzz.Models;
using BookingTourTravelBuzz.Models.Tours;

namespace BookingTourTravelBuzz.Models
{
    public class TourRepository : ITourRepository
    {
        private readonly ApplicationDbContext _context;

        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tour> GetAllDomesticTours()
        {
            return (from t in _context.TOURS
                    join a in _context.AREAS on t.ID_AREA equals a.ID_AREA
                    where t.ID_CATEGORY == 1
                    select new Tour
                    {
                        ID_TOUR = t.ID_TOUR,
                        ID_CATEGORY = t.ID_CATEGORY,
                        ID_AREA = t.ID_AREA,
                        NAME_TOUR = t.NAME_TOUR,
                        DESCRIPTION_TOUR = t.DESCRIPTION_TOUR,
                        TIME_TOUR = t.TIME_TOUR,
                        PRICE_TOUR = t.PRICE_TOUR,
                        COUNTRY_TOUR = t.COUNTRY_TOUR,
                        TRANSPORTATION_TOUR = t.TRANSPORTATION_TOUR,
                        HOTEL_TOUR = t.HOTEL_TOUR,
                        DESTINATION_TOUR = t.DESTINATION_TOUR,
                        ITINERARY_TOUR = t.ITINERARY_TOUR,
                        IMAGE_URL=t.IMAGE_URL,
                        NAME_AREA = a.NAME_AREA // Thêm tên khu vực
                    }).ToList();
        }

        public IEnumerable<Tour> GetAllInternationalTours()
        {
            return (from t in _context.TOURS
                    join a in _context.AREAS on t.ID_AREA equals a.ID_AREA
                    where t.ID_CATEGORY == 2
                    select new Tour
                    {
                        ID_TOUR = t.ID_TOUR,
                        ID_CATEGORY = t.ID_CATEGORY,
                        ID_AREA = t.ID_AREA,
                        NAME_TOUR = t.NAME_TOUR,
                        DESCRIPTION_TOUR = t.DESCRIPTION_TOUR,
                        TIME_TOUR = t.TIME_TOUR,
                        PRICE_TOUR = t.PRICE_TOUR,
                        COUNTRY_TOUR = t.COUNTRY_TOUR,
                        TRANSPORTATION_TOUR = t.TRANSPORTATION_TOUR,
                        HOTEL_TOUR = t.HOTEL_TOUR,
                        DESTINATION_TOUR = t.DESTINATION_TOUR,
                        ITINERARY_TOUR = t.ITINERARY_TOUR,
                        IMAGE_URL=t.IMAGE_URL,
                        NAME_AREA = a.NAME_AREA // Thêm tên khu vực
                    }).ToList();
        }

        public Tour? GetTourById(int id)
        {
            return (
                
                from t in _context.TOURS
                    join a in _context.AREAS on t.ID_AREA equals a.ID_AREA into areaGroup
                    from a in areaGroup.DefaultIfEmpty() // Để tránh lỗi nếu không có khu vực
                    where t.ID_TOUR == id
                    select new Tour
                    {
                        ID_TOUR = t.ID_TOUR,
                        ID_CATEGORY = t.ID_CATEGORY,
                        ID_AREA = t.ID_AREA,
                        NAME_TOUR = t.NAME_TOUR ?? "Không có tên",
                        DESCRIPTION_TOUR = t.DESCRIPTION_TOUR ?? "Không có mô tả",
                        TIME_TOUR = t.TIME_TOUR ?? "Không xác định",
                        PRICE_TOUR = t.PRICE_TOUR,
                        COUNTRY_TOUR = t.COUNTRY_TOUR ?? "Không rõ",
                        TRANSPORTATION_TOUR = t.TRANSPORTATION_TOUR ?? "Không có thông tin",
                        HOTEL_TOUR = t.HOTEL_TOUR ?? "Không rõ",
                        DESTINATION_TOUR = t.DESTINATION_TOUR ?? "Không có điểm đến",
                        ITINERARY_TOUR = t.ITINERARY_TOUR ?? "Không có lịch trình",
                        IMAGE_URL = t.IMAGE_URL ?? "",
                        Area = a != null ? new Area { ID_AREA = a.ID_AREA, NAME_AREA = a.NAME_AREA } : null
                    }).FirstOrDefault();
        }

    }
}

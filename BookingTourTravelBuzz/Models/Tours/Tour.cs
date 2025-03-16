using BookingTourTravelBuzz.Models;
using System.ComponentModel.DataAnnotations;

//namespace BookingTourTravelBuzz.Models // Thêm namespace đúng với cấu trúc của dự án
//{
    public class Tour
    {
        [Key] // Định nghĩa khóa chính
        public int ID_TOUR { get; set; }
        public int ID_CATEGORY { get; set; }
        public int ID_AREA { get; set; }
        public string? NAME_TOUR { get; set; }
        public string? DESCRIPTION_TOUR { get; set; }
        public string? TIME_TOUR { get; set; }
        public decimal PRICE_TOUR { get; set; }
        public string? COUNTRY_TOUR { get; set; }
        public string? TRANSPORTATION_TOUR { get; set; }
        public string? HOTEL_TOUR { get; set; }
        public string? DESTINATION_TOUR { get; set; }
        public string? ITINERARY_TOUR { get; set; }
        public string? IMAGE_URL { get; set; } = string.Empty;


    // Thêm thuộc tính NAME_AREA từ bảng AREA

    // Thêm navigation property để liên kết với Area
    public virtual Area? Area { get; set; }
    public string? NAME_AREA { get; set; }
}

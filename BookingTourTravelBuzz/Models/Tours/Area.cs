using System.ComponentModel.DataAnnotations;

namespace BookingTourTravelBuzz.Models
{
    public class Area
    {
        [Key]
        public int ID_AREA { get; set; }
        public int ID_CATEGORY { get; set; }
        public string? NAME_AREA { get; set; }
    }
}

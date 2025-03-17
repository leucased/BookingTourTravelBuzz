using System.ComponentModel.DataAnnotations;

namespace BookingTourTravelBuzz.Models
{
    public class Category
    {
        [Key]
        public int ID_CATEGORY { get; set; }
        public string NAME_CATEGORY { get; set; }
    }
}

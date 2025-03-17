using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTourTravelBuzz.Models
{
    public class Area
    {
        [Key]
        public int ID_AREA { get; set; }
        public int ID_CATEGORY { get; set; }
        public string NAME_AREA { get; set; }

        public virtual ICollection<Tour> TOURS { get; set; } = new List<Tour>();

        [ForeignKey("ID_CATEGORY")]
        public virtual Category Category { get; set; }

    }
}

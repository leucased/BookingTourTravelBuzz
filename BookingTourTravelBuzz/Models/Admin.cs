using System.ComponentModel.DataAnnotations;

namespace BookingTourTravelBuzz.Models
{
    public class Admin
    {
        [Key]
        public int ID_ADMIN { get; set; }

        [Required]
        public string EMAIL_ADMIN { get; set; }

        [Required]
        public string PASSWORD_ADMIN { get; set; }

        public string FULLNAME_ADMIN { get; set; }

        public string ROLE_ADMIN { get; set; }

        public string PHONE_ADMIN { get; set; }

        public DateTime? BIRTHDAY_ADMIN { get; set; }
    }
}

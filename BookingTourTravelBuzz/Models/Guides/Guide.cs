using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTourTravelBuzz.Models.Guides
{
    public class Guide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_GUIDE { get; set; }
        public string FULLNAME_GUIDE { get; set; }
        public string ROLE_GUIDE { get; set; }
        public string PHONE_GUIDE { get; set; }
        public DateTime? BIRTHDAY_GUIDE { get; set; }
        [Required]
        public string EMAIL_GUIDE { get; set; }
        public int STATUS_GUIDE { get; set; }
        public int GENDER_GUIDE { get; set; }

        public string GetGenderName()
        {
            return GENDER_GUIDE == 0 ? "Nam" : "Nữ";
        }

        public string GenderName => GetGenderName();

        public string GetStatus()
        {
            return STATUS_GUIDE == 0 ? "Nam" : "Nữ";
        }

        public string StatusGuide => GetStatus();
    }
}

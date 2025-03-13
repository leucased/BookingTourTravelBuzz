using System.ComponentModel.DataAnnotations;

namespace BookingTourTravelBuzz.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}

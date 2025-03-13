using System.ComponentModel.DataAnnotations;

namespace BookingTourTravelBuzz.ViewModels
{
    public class LoginViewModel
    {

            [Required(ErrorMessage = "Vui lòng nhập Email")]
            [EmailAddress]
            public string Email { get; set; }
        [Display(Name = "Nhập mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Ghi nhớ?")]
            public bool RememberMe { get; set; }       
    }
}

using System.ComponentModel.DataAnnotations;

namespace BookingTourTravelBuzz.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Họ Tên")]
        [Required(ErrorMessage = "Vui lòng nhập Tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Mật khẩu ít nhất phải {2} ký tự và nhiều nhất {1} ký tự.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Mật khẩu không khớp")]
        [Display(Name = "Nhập mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        public string ConfirmPassword { get; set; }
    }
}

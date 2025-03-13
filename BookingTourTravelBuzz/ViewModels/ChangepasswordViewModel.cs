using System.ComponentModel.DataAnnotations;

namespace BookingTourTravelBuzz.ViewModels
{
    public class ChangepasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Mật khẩu phải ít nhất từ {2} ký tự và nhiều nhất {1} ký tự")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        [Compare("ConfirmNewPassword", ErrorMessage = "Mật khẩu không khớp")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Nhập lại mật khẩu mới")]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu mới")]
        public string ConfirmNewPassword { get; set; }
    }
}

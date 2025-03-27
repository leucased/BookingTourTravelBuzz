using BookingTourTravelBuzz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Diagnostics;

[Area("Customer")]
[Authorize]
public class ProfileController : Controller
{
    private readonly UserManager<Customer> _userManager;
    private readonly SignInManager<Customer> _signInManager;

    public ProfileController(UserManager<Customer> userManager, SignInManager<Customer> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // Hiển thị hồ sơ cá nhân
    public async Task<IActionResult> Profile()
    {
        if (User?.Identity?.IsAuthenticated != true)
        {
            return RedirectToAction("Login", "Account");
        }
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return View(new ProfileViewModel());
        }
        var model = new ProfileViewModel
        {
            FullName = user.FullName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber ?? "Chưa cập nhật"
        };

        return View(model);
    }

    // Cập nhật hồ sơ
    [HttpPost]
    public async Task<IActionResult> UpdateProfile(ProfileViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Profile", model);
        }

        var userId = _userManager.GetUserId(User);
        if (string.IsNullOrEmpty(userId))
        {
            return RedirectToAction("Login", "Account");
        }

        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return NotFound();

        // Kiểm tra email hợp lệ trước khi truy vấn
        if (!string.IsNullOrEmpty(model.Email))
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null && existingUser.Id != user.Id)
            {
                ModelState.AddModelError("Email", "Email đã tồn tại.");
                return View("Profile", model);
            }
        }

        // Cập nhật thông tin
        user.FullName = model.FullName;
        user.Email = model.Email;
        user.NormalizedEmail = model.Email?.ToUpper(); // Kiểm tra null trước khi chuyển đổi
        user.PhoneNumber = model.PhoneNumber == "Chưa cập nhật" ? null : model.PhoneNumber;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Cập nhật thất bại.");
            return View("Profile", model);
        }

        await _signInManager.RefreshSignInAsync(user); // Đăng nhập lại nếu thay đổi email

        TempData["SuccessMessage"] = "Cập nhật thành công!";
        return RedirectToAction("Profile");
    }
}

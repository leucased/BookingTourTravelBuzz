using BookingTourTravelBuzz.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BookingTourTravelBuzz.Data
{
    public class SeedRoles
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Customer>>();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            // 1️⃣ Tạo role "Admin" và "Customer" nếu chưa có
            string[] roleNames = { "Admin", "Customer" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // 2️⃣ Lấy danh sách admin từ bảng ADMIN (tạo thủ công)
            var adminAccounts = await dbContext.ADMIN.ToListAsync();
            foreach (var admin in adminAccounts)
            {
                // 3️⃣ Kiểm tra nếu email admin đã tồn tại trong Identity
                var user = await userManager.FindByEmailAsync(admin.EMAIL_ADMIN);
                if (user == null)
                {
                    // 4️⃣ Nếu chưa có, thêm admin vào Identity
                    var newUser = new Customer
                    {
                        UserName = admin.EMAIL_ADMIN,
                        Email = admin.EMAIL_ADMIN,
                        FullName = admin.FULLNAME_ADMIN
                    };

                    var createResult = await userManager.CreateAsync(newUser, admin.PASSWORD_ADMIN);

                    if (createResult.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newUser, "Admin");
                    }
                }
                else
                {
                    // 5️⃣ Nếu tài khoản đã tồn tại, đảm bảo nó có role "Admin"
                    var roles = await userManager.GetRolesAsync(user);
                    if (!roles.Contains("Admin"))
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }
        }
    }

}

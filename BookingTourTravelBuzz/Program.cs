using BookingTourTravelBuzz.Data;
using BookingTourTravelBuzz.Models;
using BookingTourTravelBuzz.Models.Guides;
using BookingTourTravelBuzz.Models.Tours;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<IGuideRepostory, GuideRepository>();


builder.Services.AddIdentity<Customer, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await SeedRoles.Initialize(serviceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.UseEndpoints(endpoints =>
{
    // Route cho area Customer
    endpoints.MapAreaControllerRoute(
        name: "CustomerArea",
        areaName: "Customer",
        pattern: "Customer/{controller=Customer}/{action=Profile}/{id?}");

    // Route cho các areas khác
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=TourManager}/{action=Domestic}/{id?}");

    // Route mặc định
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Home}/{id?}")
        .WithStaticAssets();
});

app.Run();



using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTourTravelBuzz.Models
{
    public class Customer : IdentityUser
    {
        [PersonalData]
        [Column("FullName")] // Đảm bảo ánh xạ đúng tên cột
        public string? FullName { get; set; }
    }
}
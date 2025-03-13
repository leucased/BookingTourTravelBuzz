using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace BookingTourTravelBuzz.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}

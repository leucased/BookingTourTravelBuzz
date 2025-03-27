using BookingTourTravelBuzz.Models.Guides;
using BookingTourTravelBuzz.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Booking
{
    [Key]
    public int ID_BOOKING { get; set; }

    // Liên kết với Tour
    [ForeignKey("Tour")]
    public int ID_TOUR { get; set; }
    public virtual Tour Tour { get; set; }

    // ✅ Đổi ID_CUSTOMER → Id để trùng với AspNetUsers.Id (string)
    [ForeignKey("Customer")]
    public string? Id { get; set; }
    public virtual Customer? Customer { get; set; }

    public DateTime START_DATES { get; set; }

    [Required]
    [StringLength(100)]
    public string? FULLNAME_CUSTOMER { get; set; }

    [Required]
    [StringLength(15)]
    public string? PHONE_CUSTOMER { get; set; }

    [Required]
    [StringLength(30)]
    public string? EMAIL_CUSTOMER { get; set; }

    // Liên kết với Guide (hướng dẫn viên)
    [ForeignKey("Guide")]
    public int ID_GUIDE { get; set; }
    public virtual Guide Guide { get; set; }

    [Required]
    public int QUANTITY_BOOKING { get; set; }

    [Required]
    public decimal TOTAL_PRICE { get; set; }

    public DateTime BOOKING_DATE { get; set; }

    [Required]
    [StringLength(50)]
    public string? STATUS_BOOKING { get; set; }
}

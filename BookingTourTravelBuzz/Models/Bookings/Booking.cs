using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTourTravelBuzz.Models
{
    public class Booking
    {
        [Key]
        public int ID_BOOKING { get; set; } // Khóa chính

        [Required]
        public int ID_TOUR { get; set; } // Khóa ngoại - Tour

        [Required]
        public string ID_CUSTOMER { get; set; } // Khóa ngoại - Khách hàng

        [Required]
        public string FULLNAME_CUSTOMER { get; set; }

        [Required]
        public string PHONE_CUSTOMER { get; set; }

        [Required, EmailAddress]
        public string EMAIL_CUSTOMER { get; set; }

        public int ID_GUIDE { get; set; } // Hướng dẫn viên (nếu có)

        [Required]
        public int QUANTITY { get; set; } // Số lượng khách

        [Required]
        public decimal TOTAL_PRICE { get; set; } // Tổng giá tiền

        public DateTime BOOKING_DATE { get; set; } = DateTime.Now; // Ngày đặt

        public string STATUS_BOOKING { get; set; } = "Chờ xác nhận"; // Trạng thái

        public DateTime START_DATE { get; set; } // Ngày khởi hành

        // Navigation properties
        [ForeignKey("ID_TOUR")]
        public virtual Tour Tour { get; set; }

        [ForeignKey("ID_CUSTOMER")]
        public virtual Customer Customer { get; set; }
    }
}

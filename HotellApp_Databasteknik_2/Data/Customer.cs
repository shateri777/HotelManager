using System.ComponentModel.DataAnnotations;

namespace HotellApp_Databasteknik_2.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(100)]  // Anger längden på FirstName till 100 tecken
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]  // Anger längden på LastName till 100 tecken
        public string LastName { get; set; }

        [StringLength(256)]  // Anger längden på Email till 256 tecken
        public string? Email { get; set; }

        [StringLength(15)]  // Anger längden på PhoneNumber till 15 tecken
        public string? PhoneNumber { get; set; }
        public ICollection<Booking>? Bookings { get; set; } = new List<Booking>();
        public bool IsActive { get; set; } = true;
    }
}

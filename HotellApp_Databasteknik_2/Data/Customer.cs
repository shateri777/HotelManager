namespace HotellApp_Databasteknik_2.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Booking>? Bookings { get; set; } = new List<Booking>();
        public bool IsActive { get; set; } = true;
    }
}

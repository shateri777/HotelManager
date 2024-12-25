using HotellApp_Databasteknik_2.Migrations;

namespace HotellApp_Databasteknik_2.Data
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalPrice { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

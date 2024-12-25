using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Interfaces;
namespace HotellApp_Databasteknik_2.Utilities.CRUD.Bookings
{
    public class ReadBooking : IRead
    {
        public void Read()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var activeBookings = dbContext.Booking.Where(b => b.IsActive == true).ToList();
                if (activeBookings.Count > 0)
                {
                    Console.Clear();
                    foreach (var b in activeBookings)
                    {
                        Console.WriteLine($"BookingID: {b.BookingId}, (FK)CustomerID: {b.CustomerId}, (FK)RoomID: {b.RoomId}, Start date: {b.CheckInDate}, End date: {b.CheckOutDate}");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det finns inga aktiva bokningar just nu.");
                    Console.ResetColor();
                }
                Console.WriteLine("Tryck valfri knapp för att gå tillbaka..");
                Console.ReadKey();
            }
        }
    }
}

using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace HotellApp_Databasteknik_2.Utilities.CRUD.Bookings
{
    public class DeleteBooking : IDelete
    {
        public void Delete()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var bookings = dbContext.Booking.Where(c => c.IsActive);
                foreach (var b in bookings)
                {
                    Console.WriteLine($"BookingID: {b.BookingId}, (FK)CustomerID:{b.CustomerId},  (FK)RoomID{b.RoomId}");
                }
                if (dbContext.Booking.Any(c => c.IsActive))
                {
                    Console.WriteLine("Vilken bokning vill du ta bort?");
                    var bookingIdInput = Convert.ToInt32(Console.ReadLine());
                    var chosenBooking = dbContext.Booking.FirstOrDefault(b => b.BookingId == bookingIdInput);

                    if (chosenBooking != null && chosenBooking.IsActive == true)
                    {
                        chosenBooking.IsActive = false;
                        Console.WriteLine($"Du har valt att ta bort (BookingId:{chosenBooking.BookingId}, CustomerId: {chosenBooking.CustomerId}, RoomId: {chosenBooking.RoomId})");
                        Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                        Console.ReadKey();
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ingen bokning hittades med angivet ID.");
                        Console.ResetColor();
                        Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det finns inga bokningar just nu..");
                    Console.ResetColor();
                    Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                    Console.ReadKey();
                }
            }
        }
    }
}

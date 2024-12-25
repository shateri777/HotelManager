using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Interfaces;
namespace HotellApp_Databasteknik_2.Utilities.CRUD.Bookings
{
    public class UpdateBooking : IUpdate
    {
        private readonly CalendarForBooking _calendarForBooking;
        public UpdateBooking(CalendarForBooking calendarForBooking)
        {
            _calendarForBooking = calendarForBooking;
        }
        public void Update()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                if (dbContext.Booking.Any())
                {
                    Console.WriteLine("Vill du ändra på någon bokning(1) eller ta tillbaka en raderad bokning?(2).  (Svara med 1/2) ");
                    char userInputForUpdateBooking = Convert.ToChar(Console.ReadLine());
                    if (userInputForUpdateBooking == '1')
                    {
                        foreach (var b in dbContext.Booking)
                        {
                            Console.WriteLine($"BookingID: {b.BookingId}, (FK)RoomID: {b.RoomId}, (FK)CustomerID: {b.CustomerId}, Start date: {b.CheckInDate}, End date: {b.CheckOutDate}");
                        }
                        Console.WriteLine("Vilken bokning vill du uppdatera?");
                        var bookingIdInput = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        var chosenBooking = dbContext.Booking.FirstOrDefault(b => b.BookingId == bookingIdInput);
                        if (chosenBooking != null)
                        {
                            Console.WriteLine("Vilken kund ska stå på bokningen?");
                            var customer = dbContext.Customer.Where(c => c.IsActive == true);
                            foreach (var c in customer)
                            {
                                Console.WriteLine($"ID {c.CustomerId}: {c.FirstName} {c.LastName}, {c.Email}, {c.PhoneNumber}");
                            }
                            var customerIdInput = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            var chosenCustomer = dbContext.Customer.FirstOrDefault(c => c.CustomerId == customerIdInput);
                            if (chosenCustomer != null && chosenCustomer.IsActive != false)
                            {
                                chosenBooking.CustomerId = chosenCustomer.CustomerId;
                                Console.WriteLine($"Kunden {chosenCustomer.FirstName} har valts för bokningen.");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ingen kund hittades med angivet ID.");
                                Console.ResetColor();
                                Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                                Console.ReadKey();
                                return;
                            }
                            Console.WriteLine("Vilket rum ska kunden byta till?");
                            var rooms = dbContext.Room.Where(c => c.IsActive == true);
                            foreach (var r in rooms)
                            {
                                Console.WriteLine($"ID: {r.RoomId}, {r.RoomType}, Price: {r.PricePerNight}, Amount of beds: {r.Bed}");
                            }
                            var roomIdInput = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            var chosenRoom = dbContext.Room.FirstOrDefault(b => b.RoomId == roomIdInput);
                            if(chosenRoom != null && chosenRoom.IsActive != false)
                            {
                                chosenBooking.RoomId = chosenRoom.RoomId;
                                Console.WriteLine($"Rummet ({chosenRoom.RoomId}, {chosenRoom.RoomType}, Price: {chosenRoom.PricePerNight} Amount of Beds: {chosenRoom.Bed}) har valts för bokningen.");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Inget rum hittades med angivet ID.");
                                Console.ResetColor();
                                Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                                Console.ReadKey();
                                return;
                            }
                            Console.WriteLine("Vad är check-in datumet för bokningen?");
                            Console.WriteLine($"Tryck valfri knapp för att gå till kalendern");
                            Console.ReadKey();
                            chosenBooking.CheckInDate = _calendarForBooking.ShowCalendar();
                            Console.Clear();
                            Console.WriteLine("Vad är check-out datumet för bokningen?");
                            Console.WriteLine($"Tryck valfri knapp för att gå till kalendern");
                            Console.ReadKey();
                            chosenBooking.CheckOutDate = _calendarForBooking.ShowCalendar().AddDays(1).AddTicks(-1);

                            Console.WriteLine($"CustomerId: {chosenBooking.CustomerId}, {chosenCustomer.FirstName} {chosenCustomer.LastName}");
                            Console.WriteLine($"RoomId: {chosenBooking.RoomId}, {chosenRoom.RoomType}, Price: {chosenRoom.PricePerNight}");
                            Console.WriteLine($"Booking Id:{chosenBooking.BookingId}, (FK)CustomerId {chosenBooking.CustomerId}, (FK)RoomId: {chosenBooking.RoomId},  Check-In: {chosenBooking.CheckInDate}, Check-Out: {chosenBooking.CheckOutDate}");
                            Console.WriteLine($"Är du nöjd med bokningen? (Skriv 'J' om du vill bekräfta bokningen, annars tryck valfri knapp).");
                            char userInputForBooking = Convert.ToChar(Console.ReadLine().ToUpper());
                            if (userInputForBooking == 'J')
                            {
                                dbContext.SaveChanges();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Bokningen är genomförd!");
                                Console.ResetColor();
                                Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Bokningen är avbruten.");
                                Console.ResetColor();
                                Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ingen bokning hittades med angivet ID.");
                            Console.ResetColor();
                            Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                            Console.ReadKey();
                            return;
                        }
                    }
                    else if (userInputForUpdateBooking == '2')
                    {
                        var deletedBookings = dbContext.Booking.Where(b => b.IsActive == false).ToList();
                        if (deletedBookings.Count > 0)
                        {
                            foreach (var b in deletedBookings)
                            {
                                Console.WriteLine($"BookingID: {b.BookingId}, (FK)RoomID: {b.RoomId}, (FK)CustomerID: {b.CustomerId}, Start date: {b.CheckInDate}, End date: {b.CheckOutDate}");
                            }
                            Console.WriteLine("Vilken bokning vill du ta tillbaka? (Välj ID)");
                            var bookingIdInput = Convert.ToInt32(Console.ReadLine());
                            var chosenBooking = dbContext.Booking.FirstOrDefault(b => b.BookingId == bookingIdInput);
                            if (chosenBooking != null && chosenBooking.IsActive == false)
                            {
                                chosenBooking.IsActive = true;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Bokningen är nu aktiv!");
                                Console.ResetColor();
                                Console.WriteLine($"BookingID: {chosenBooking.BookingId}, (FK)RoomID: {chosenBooking.RoomId}, (FK)CustomerID: {chosenBooking.CustomerId}, Start date: {chosenBooking.CheckInDate}, End date: {chosenBooking.CheckOutDate}");
                                Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                                Console.ReadKey();
                                dbContext.SaveChanges();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Bokningen finns inte eller är redan aktiv...");
                                Console.ResetColor();
                                Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                                Console.ReadKey();
                                return;
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Det finns inga raderade kunder just nu...");
                        Console.ResetColor();
                        Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                        Console.ReadKey();
                        return;
                    }
                }
            }
        }
    }
}

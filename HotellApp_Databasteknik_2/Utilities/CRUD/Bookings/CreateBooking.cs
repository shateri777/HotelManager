using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Interfaces;
using HotellApp_Databasteknik_2.Utilities.Calendar;
namespace HotellApp_Databasteknik_2.Utilities.CRUD.Bookings
{
    public class CreateBooking : ICreate
    {
        private readonly CalendarForBooking _calendarForBooking;
        public CreateBooking(CalendarForBooking calendarForBooking)
        {
            _calendarForBooking = calendarForBooking;
        }
        public void Create()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                if (dbContext.Customer != null && dbContext.Room != null)
                {
                    Console.WriteLine("Vilken kund är det som ska bokas in? (Välj ett KundID)");
                    var activeCustomers = dbContext.Customer.Where(c => c.IsActive == true).ToList();
                    foreach (var c in activeCustomers)
                    {
                        Console.WriteLine($"CustomerID: {c.CustomerId}, {c.FirstName} {c.LastName}");
                    }
                    int userInputForCustomerId;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out userInputForCustomerId) && activeCustomers.Any(c => c.CustomerId == userInputForCustomerId))
                        {
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        Console.ResetColor();
                    }
                    Console.Clear();
                    var chosenCustomer = dbContext.Customer.FirstOrDefault(c => c.CustomerId == userInputForCustomerId);
                    Console.WriteLine("Vilket rum är det som kunden ska stanna i? (Välj ett RumID)");
                    var activeRooms = dbContext.Room.Where(r => r.IsActive == true).ToList();
                    foreach (var r in activeRooms)
                    {
                        Console.WriteLine($"RoomID: {r.RoomId}, Room typ: {r.RoomType}, Price: {r.PricePerNight}, Amount of beds: {r.Bed}");
                    }
                    int userInputForRoomId;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out userInputForRoomId) && activeRooms.Any(r => r.RoomId == userInputForRoomId))
                        {
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        Console.ResetColor();
                    }
                    Console.Clear();
                    var chosenRoom = dbContext.Room.FirstOrDefault(r => r.RoomId == userInputForRoomId);
                    Console.WriteLine("Vad är check-in datumet för bokningen?");
                    Console.WriteLine($"Tryck valfri knapp för att gå till kalendern");
                    Console.ReadKey();
                    DateTime startDate = _calendarForBooking.ShowCalendar();
                    Console.Clear();
                    Console.WriteLine("Vad är check-out datumet för bokningen?");
                    Console.WriteLine($"Tryck valfri knapp för att gå till kalendern");
                    Console.ReadKey();
                    DateTime endDate = _calendarForBooking.ShowCalendar().AddDays(1).AddTicks(-1);
                    int totalDays = (endDate.Date - startDate.Date).Days;
                    if (totalDays == 0)
                    {
                        totalDays = 1;
                    }
                    int totalPrice = totalDays * chosenRoom.PricePerNight;
                    Console.WriteLine($"Du har valt kund: {chosenCustomer.CustomerId}, {chosenCustomer.FirstName} {chosenCustomer.LastName}");
                    Console.WriteLine($"Du har valt rum: {chosenRoom.RoomId}, {chosenRoom.RoomType} Price: {chosenRoom.PricePerNight}, Amount of beds: {chosenRoom.Bed}");
                    Console.WriteLine($"Check in datum: {startDate}");
                    Console.WriteLine($"Check out datum: {endDate}");
                    Console.WriteLine($"Totalpris för bokningen: {totalPrice} kr");
                    Console.WriteLine($"Är du nöjd med bokningen? (Skriv 'J' om du vill bekräfta bokningen annars skriv 'N' om du vill avbryta).");
                    char userInputForBooking = Convert.ToChar(Console.ReadLine().ToUpper());
                    if (userInputForBooking == 'J')
                    {
                        var newBooking = new Booking
                        {
                            CustomerId = chosenCustomer.CustomerId,
                            RoomId = chosenRoom.RoomId,
                            CheckInDate = startDate,
                            CheckOutDate = endDate,
                            TotalPrice = totalPrice
                        };
                        dbContext.Booking.Add(newBooking);
                        dbContext.SaveChanges();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Bokningen är genomförd!");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    else if (userInputForBooking == 'N')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bokningen är avbruten.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}

using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace HotellApp_Databasteknik_2.Utilities.CRUD.Customers
{
    public class ReadCustomer : IRead
    {
        public void Read()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var customers = dbContext.Customer.Include(c => c.Bookings).ToList();
                if(dbContext.Customer.Any(c => c.IsActive))
                {
                    foreach (var c in customers)
                    {
                        if (c.IsActive)
                        {
                            Console.WriteLine($"ID {c.CustomerId}: {c.FirstName} {c.LastName}, {c.Email}, {c.PhoneNumber}");
                            if (c.Bookings != null && c.Bookings.Any(c => c.IsActive == true))
                            {
                                int totalBookings = 0;
                                foreach (var b in c.Bookings)
                                {
                                    totalBookings =+ c.Bookings.Count;
                                }
                                Console.WriteLine($"Total active bookings: {totalBookings}");
                            }
                            else
                            {
                                Console.WriteLine("Bookings: N/A");
                            }
                        }
                    }
                    Console.WriteLine("Tryck valfri knapp för att gå vidare..");
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det finns inga kunder än...");
                    Console.ResetColor();
                    Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                    Console.ReadKey();
                }
            }
        }
    }
}

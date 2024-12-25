using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Interfaces;
namespace HotellApp_Databasteknik_2.Utilities.CRUD.Customers
{
    public class DeleteCustomer : IDelete
    {
        public void Delete()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var customers = dbContext.Customer.Where(c => c.IsActive);
                foreach (var c in customers)
                {
                    Console.WriteLine($"ID: {c.CustomerId}, {c.FirstName} {c.LastName}");
                }
                if (dbContext.Customer.Any(c => c.IsActive))
                    {
                    Console.WriteLine("Vilken kund vill du ta bort?");
                    var customerIdInput = Convert.ToInt32(Console.ReadLine());
                    var chosenCustomer = dbContext.Customer.FirstOrDefault(c => c.CustomerId == customerIdInput);

                    if (chosenCustomer != null && chosenCustomer.IsActive == true)
                    {
                        chosenCustomer.IsActive = false;
                        Console.WriteLine($"Du har valt att ta bort (ID:{chosenCustomer.CustomerId}, {chosenCustomer.FirstName} {chosenCustomer.LastName})");
                        Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                        Console.ReadKey();
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ingen kund hittades med angivet ID.");
                        Console.ResetColor();
                        Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det finns inga kunder just nu..");
                    Console.ResetColor();
                    Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                    Console.ReadKey();
                }
            }
        }
    }
}

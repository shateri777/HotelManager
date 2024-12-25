using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Interfaces;
namespace HotellApp_Databasteknik_2.Utilities.CRUD.Customers
{
    public class UpdateCustomer : IUpdate
    {
        public void Update()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                if (dbContext.Customer.Any())
                {
                    Console.WriteLine("Vill du ändra kundinformation(1) eller ta tillbaka en raderad kund?(2).  (Svara med 1/2) ");
                    char userInputForUpdateCustomer = Convert.ToChar(Console.ReadLine());
                    if (userInputForUpdateCustomer == '1')
                    {
                        var customers = dbContext.Customer.OrderByDescending(c=> c.IsActive).ToList();
                        foreach (var c in customers)
                        {
                            Console.WriteLine($"ID: {c.CustomerId}, {c.FirstName} {c.LastName}. (Aktiv Kund: {c.IsActive})");
                        }
                        Console.WriteLine("Vilken kund vill du uppdatera?");
                        var customerIdInput = Convert.ToInt32(Console.ReadLine());
                        var chosenCustomer = dbContext.Customer.FirstOrDefault(c => c.CustomerId == customerIdInput);
                        if (chosenCustomer != null)
                        {
                            Console.WriteLine("Vad heter kunden förnamn?");
                            chosenCustomer.FirstName = Console.ReadLine();

                            Console.WriteLine("Vad heter kundens efternamn?");
                            chosenCustomer.LastName = Console.ReadLine();

                            Console.WriteLine("Vad är kundens email?");
                            chosenCustomer.Email = Console.ReadLine();

                            Console.WriteLine("Vad är kundens telnr?");
                            chosenCustomer.PhoneNumber = Console.ReadLine();

                            dbContext.SaveChanges();
                            return;
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
                    }
                    else if (userInputForUpdateCustomer == '2')
                    {
                        var deletedCustomers = dbContext.Customer.Where(c => c.IsActive == false).ToList();
                        if(deletedCustomers.Count > 0)
                        {
                            foreach (var c in deletedCustomers)
                            {
                                Console.WriteLine($"ID: {c.CustomerId}, {c.FirstName} {c.LastName}. (Aktiv Kund: {c.IsActive})");
                            }
                            Console.WriteLine("Vilken kund vill du ta tillbaka? (Välj ID)");
                            var customerIdInput = Convert.ToInt32(Console.ReadLine());
                            var chosenCustomer = dbContext.Customer.FirstOrDefault(c => c.CustomerId == customerIdInput);
                            if (chosenCustomer != null && chosenCustomer.IsActive == false)
                            {
                                chosenCustomer.IsActive = true;
                                Console.WriteLine("Kunden är nu aktiv!");
                                Console.WriteLine($"ID: {chosenCustomer.CustomerId}, {chosenCustomer.FirstName} {chosenCustomer.LastName}. (Aktiv Kund: {chosenCustomer.IsActive})");
                                Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                                Console.ReadKey();
                                dbContext.SaveChanges();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Kunden finns inte eller är redan aktiv...");
                                Console.ResetColor();
                                Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Det finns inga raderade kunder just nu...");
                            Console.ResetColor();
                            Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du får bara välja mellan 1 och 2...");
                        Console.ResetColor();
                        Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det finns inga kunder just nu..");
                    Console.ResetColor();
                    Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                    Console.ReadKey();
                }
            }
        }
    }
}

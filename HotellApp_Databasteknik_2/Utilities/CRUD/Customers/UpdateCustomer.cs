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
                            Console.WriteLine($"ID: {c.CustomerId}, {c.FirstName} {c.LastName}. Active {c.IsActive}");
                        }
                        Console.WriteLine("Vilken kund vill du uppdatera?");
                        var customerIdInput = Convert.ToInt32(Console.ReadLine());
                        var chosenCustomer = dbContext.Customer.FirstOrDefault(c => c.CustomerId == customerIdInput);
                        if (chosenCustomer != null)
                        {
                            Console.WriteLine("Vad heter kunden förnamn? (Max 100 karaktärer)");
                            chosenCustomer.FirstName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(chosenCustomer.FirstName) || chosenCustomer.FirstName.Length > 100)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Förnamnet kan inte vara tomt eller överstiga 100 karaktärer.");
                                Console.ResetColor();
                                Console.ReadKey();
                                return;
                            }
                            Console.WriteLine("Vad heter kundens efternamn? (Max 100 karaktärer)");
                            chosenCustomer.LastName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(chosenCustomer.LastName) || chosenCustomer.LastName.Length > 100)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Efternamnet kan inte vara tomt eller överstiga 100 karaktärer.");
                                Console.ResetColor();
                                Console.ReadKey();
                                return;
                            }
                            Console.WriteLine("Vad är kundens email? (Max 256 karaktärer)");
                            chosenCustomer.Email = Console.ReadLine();
                            if (chosenCustomer.Email.Length > 256)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Kundens email kan inte överstiga 256 karaktärer.");
                                Console.ResetColor();
                                Console.ReadKey();
                                return;
                            }
                            Console.WriteLine("Vad är kundens telnr? (Max 15 karaktärer)");
                            chosenCustomer.PhoneNumber = Console.ReadLine();
                            if (chosenCustomer.PhoneNumber.Length > 15)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Telefonnummret kan inte överstiga 15 karaktärer.");
                                Console.ResetColor();
                                Console.ReadKey();
                                return;
                            }
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
                                Console.WriteLine($"ID: {c.CustomerId}, {c.FirstName} {c.LastName}. Active {c.IsActive}");
                            }
                            Console.WriteLine("Vilken kund vill du ta tillbaka? (Välj ID)");
                            var customerIdInput = Convert.ToInt32(Console.ReadLine());
                            var chosenCustomer = dbContext.Customer.FirstOrDefault(c => c.CustomerId == customerIdInput);
                            if (chosenCustomer != null && chosenCustomer.IsActive == false)
                            {
                                chosenCustomer.IsActive = true;
                                Console.WriteLine("Kunden är nu aktiv!");
                                Console.WriteLine($"ID: {chosenCustomer.CustomerId}, {chosenCustomer.FirstName} {chosenCustomer.LastName}. Active: {chosenCustomer.IsActive}");
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

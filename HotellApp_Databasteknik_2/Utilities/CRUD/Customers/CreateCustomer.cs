using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Interfaces;
namespace HotellApp_Databasteknik_2.Utilities.CRUD.Customers
{
    public class CreateCustomer : ICreate
    {
        public void Create()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                Console.WriteLine("Vad heter kunden förnamn? (Max 100 karaktärer)");
                string customerFirstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customerFirstName) || customerFirstName.Length > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Förnamnet kan inte vara tomt eller överstiga 100 karaktärer.");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Vad heter kundens efternamn? (Max 100 karaktärer)");
                string customerLastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customerLastName) || customerLastName.Length > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Efternamnet kan inte vara tomt eller överstiga 100 karaktärer.");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Vad är kundens email? (Max 256 karaktärer)");
                string customerEmail = Console.ReadLine();
                if (customerEmail.Length > 256)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Kundens email kan inte överstiga 256 karaktärer.");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Vad är kundens telnr? (Max 15 karaktärer)");
                string customerPhoneNumber = Console.ReadLine();
                if (customerPhoneNumber.Length > 15)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Telefonnummret kan inte överstiga 15 karaktärer.");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }
                dbContext.Add(new Customer
                {
                    FirstName = customerFirstName,
                    LastName = customerLastName,
                    Email = customerEmail,
                    PhoneNumber = customerPhoneNumber,
                    IsActive = true
                });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Kunden är registrerad!");
                Console.ResetColor();
                Console.ReadKey();
                dbContext.SaveChanges();
            }
        }
    }
}


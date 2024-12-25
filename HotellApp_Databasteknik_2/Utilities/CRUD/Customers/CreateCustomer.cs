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
                Console.WriteLine("Vad heter kunden förnamn?");
                string customerFirstName = Console.ReadLine();

                Console.WriteLine("Vad heter kundens efternamn?");
                string customerLastName = Console.ReadLine();

                Console.WriteLine("Vad är kundens email?");
                string customerEmail = Console.ReadLine();

                Console.WriteLine("Vad är kundens telnr?");
                string customerPhoneNumber = Console.ReadLine();

                dbContext.Add(new Customer
                {
                    FirstName = customerFirstName,
                    LastName = customerLastName,
                    Email = customerEmail,
                    PhoneNumber = customerPhoneNumber,
                    IsActive = true
                });
                dbContext.SaveChanges();
            }
        }
    }
}


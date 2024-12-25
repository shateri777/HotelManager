using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace HotellApp_Databasteknik_2.Data
{
    public class Data_Initializer
    {
        public void MigrateAndSeed()
        {
            // Läser appsettings och skapar DbContextOptions
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true);
            var config = builder.Build();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                dbContext.Database.Migrate();
                SeedData(dbContext);
            }
        }
        private void SeedData(ApplicationDbContext context)
        {
            if (!context.Room.Any())
            {
                context.Room.AddRange(
                    new Room { RoomType = RoomType.Single, PricePerNight = 100, Bed = 1, IsActive = true },
                    new Room { RoomType = RoomType.Double, PricePerNight = 150, Bed = 2, IsActive = true },
                    new Room { RoomType = RoomType.Single, PricePerNight = 120, Bed = 1, IsActive = true },
                    new Room { RoomType = RoomType.Double, PricePerNight = 200, Bed = 3, IsActive = true }
                );
            }

            if (!context.Customer.Any())
            {
                context.Customer.AddRange(
                    new Customer { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890", IsActive = true },
                    new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "0987654321", IsActive = true },
                    new Customer { FirstName = "Bob", LastName = "Johnson", Email = "bob.johnson@example.com", PhoneNumber = "1122334455", IsActive = true },
                    new Customer { FirstName = "Alice", LastName = "Williams", Email = "alice.williams@example.com", PhoneNumber = "6677889900", IsActive = true }
                );
            }

            context.SaveChanges();
        }
    }
}

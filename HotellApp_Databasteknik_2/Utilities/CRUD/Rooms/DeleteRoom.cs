using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Interfaces;
namespace HotellApp_Databasteknik_2.Utilities.CRUD.Rooms
{
    public class DeleteRoom : IDelete
    {
        public void Delete()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var deletedRooms = dbContext.Room.Where(c => c.IsActive);
                foreach (var r in deletedRooms)
                {
                    Console.WriteLine($"ID:{r.RoomId}, {r.RoomType} Price: {r.PricePerNight}. Amount of beds: {r.Bed})");
                }
                if (dbContext.Customer.Any(c => c.IsActive))
                {
                    Console.WriteLine("Vilket rum vill du ta bort?");
                    var roomIdInput = Convert.ToInt32(Console.ReadLine());
                    var chosenRoom = dbContext.Room.FirstOrDefault(r => r.RoomId == roomIdInput);

                    if (chosenRoom != null && chosenRoom.IsActive == true)
                    {
                        chosenRoom.IsActive = false;
                        Console.WriteLine($"Du har valt att ta bort (ID:{chosenRoom.RoomId}, {chosenRoom.RoomType} Price: {chosenRoom.PricePerNight}. Amount of beds: {chosenRoom.Bed})");
                        Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                        Console.ReadKey();
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Inget rum hittades med angivet ID.");
                        Console.ResetColor();
                        Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det finns inga rum just nu..");
                    Console.ResetColor();
                    Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                    Console.ReadKey();
                }
            }
        }
    }
}

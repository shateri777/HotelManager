using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Interfaces;
namespace HotellApp_Databasteknik_2.Utilities.CRUD.Rooms
{
    public class ReadRoom : IRead
    {
        public void Read()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var activeRooms = dbContext.Room.Where(r => r.IsActive == true).ToList();
                if (activeRooms.Count > 0)
                {
                    Console.Clear();
                    Console.Clear();
                    foreach (var r in activeRooms)
                    {
                        Console.WriteLine($"ID: {r.RoomId}, {r.RoomType}, Price: {r.PricePerNight}, Amount of beds: {r.Bed}");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det finns inga aktiva rum just nu.");
                    Console.ResetColor();
                }
                Console.WriteLine("Tryck valfri knapp för att gå vidare..");
                Console.ReadKey();
            }
        }
    }
}

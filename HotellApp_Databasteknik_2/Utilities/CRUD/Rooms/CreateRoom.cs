using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Interfaces;
namespace HotellApp_Databasteknik_2.Utilities.CRUD.Rooms
{
    public class CreateRoom : ICreate
    {
        public void Create()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                int amountOfBeds = 0;
                Console.WriteLine("Vad är det för rum typ? Singelrum eller dubbelrum? | Kommandon: (Single/Double) eller (1/2)?");
                string userInput = Console.ReadLine();
                Enum.TryParse(userInput, true, out RoomType roomType);
                if (roomType == RoomType.Double)
                {
                    Console.WriteLine("Ange hur många extra sängar du vill ha (Max 2 extra sängar för dubbelrum):");
                    amountOfBeds = Convert.ToInt32(Console.ReadLine());
                    if (amountOfBeds >= 0 && amountOfBeds <= 2)
                    {
                        amountOfBeds += 2;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du får bara välja antingen 0 till max 2 extra sängar.");
                        Console.ResetColor();
                        Console.WriteLine("Tryck valfri knapp för att gå tillbaka...");
                        Console.ReadKey();
                        return;
                    }
                }
                else if (roomType == RoomType.Single)
                {
                    {
                        amountOfBeds += 1;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du får bara välja mellan Single/Double");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Hur mycket kostar det att bo där per natt?");
                int pricePerNight = Convert.ToInt32(Console.ReadLine());
                dbContext.Add(new Room
                {
                    RoomType = roomType,
                    PricePerNight = pricePerNight,
                    Bed = amountOfBeds,
                    IsActive = true
                });
                dbContext.SaveChanges();
            }
        }
    }
}

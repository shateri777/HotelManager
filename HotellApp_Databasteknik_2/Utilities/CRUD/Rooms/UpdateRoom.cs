using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Interfaces;
namespace HotellApp_Databasteknik_2.Utilities.CRUD.Rooms
{
    public class UpdateRoom : IUpdate
    {
        public void Update()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                if (dbContext.Room.Any())
                {
                    Console.WriteLine("Vill du ändra på något rum(1) eller ta tillbaka ett raderad rum?(2).  (Svara med 1/2) ");
                    char userInputForUpdateRoom = Convert.ToChar(Console.ReadLine());
                    if (userInputForUpdateRoom == '1')
                    {
                        var rooms = dbContext.Room.OrderByDescending(r => r.IsActive).ToList();
                        foreach (var r in rooms)
                        {
                            Console.WriteLine($"ID: {r.RoomId}, {r.RoomType}, Price: {r.PricePerNight}, Amount of beds: {r.Bed}, Active: {r.IsActive}");
                        }
                        Console.WriteLine("Vilket rum vill du uppdatera? (Välj ett RumID)");
                        var roomIdInput = Convert.ToInt32(Console.ReadLine());
                        var chosenRoom = dbContext.Room.FirstOrDefault(c => c.RoomId == roomIdInput);
                        if (chosenRoom != null)
                        {
                            Console.WriteLine("Vad ska rumtypet vara? Single eller Double? (Svara med: Single/Double eller 1/2)");
                            string userInput = Console.ReadLine();
                            Enum.TryParse(userInput, true, out RoomType roomType);
                            if (roomType != RoomType.Single && roomType != RoomType.Double)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Du får bara välja mellan Single och Double...");
                                Console.ResetColor();
                                Console.ReadKey();
                                return;
                            }
                            chosenRoom.RoomType = roomType;
                            Console.WriteLine("Hur mycket kostar det att bo där per natt? (Min 100kr - Max 1000kr)");
                            Console.WriteLine("(Ange bara en siffra och inte en valuta)");
                            chosenRoom.PricePerNight = Convert.ToInt32(Console.ReadLine());
                            if (chosenRoom.PricePerNight > 1000 || chosenRoom.PricePerNight < 100)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Priset måste minst vara 100kr eller max 1000 kr per natt");
                                Console.ResetColor();
                                Console.ReadKey();
                                return;
                            }
                            if (chosenRoom.RoomType == RoomType.Double)
                            {
                                Console.WriteLine("Ange hur många EXTRA sängar du vill ha (Du har 2 sängar som standard. Om du inte vill ha extra sängar, skriv 0. Du får välja upp till MAX 2 extra sängar för dubbelrum).)");
                                int amountOfBeds = Convert.ToInt32(Console.ReadLine());
                                if (amountOfBeds >= 0 && amountOfBeds <= 2)
                                {
                                    chosenRoom.Bed += amountOfBeds;
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
                            else if (chosenRoom.RoomType == RoomType.Single)
                            {
                                chosenRoom.Bed = 1;
                            }
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
                    else if (userInputForUpdateRoom == '2')
                    {
                        var deletedRoom = dbContext.Room.Where(r => r.IsActive == false).ToList();
                        if (deletedRoom.Count > 0)
                        {
                            foreach (var r in deletedRoom)
                            {
                                Console.WriteLine($"ID: {r.RoomId}, {r.RoomType}, Active: {r.IsActive}");
                            }
                            Console.WriteLine("Vilket rum vill du ta tillbaka? (Välj ID)");
                            var roomIdInput = Convert.ToInt32(Console.ReadLine());
                            var chosenRoom = dbContext.Room.FirstOrDefault(r => r.RoomId == roomIdInput);
                            if (chosenRoom != null && chosenRoom.IsActive == false)
                            {
                                chosenRoom.IsActive = true;
                                Console.WriteLine("Rummet är nu aktiv!");
                                Console.WriteLine($"ID: {chosenRoom.RoomId}, {chosenRoom.RoomType}, Active: {chosenRoom.IsActive}");
                                Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                                Console.ReadKey();
                                dbContext.SaveChanges();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Rummet finns inte eller är redan aktiv...");
                                Console.ResetColor();
                                Console.WriteLine($"Tryck valfri knapp för att gå tillbaka...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Det finns inga raderade rum just nu..");
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
                    Console.WriteLine("Det finns inga rum just nu..");
                    Console.ResetColor();
                    Console.WriteLine($"Tryck valfri knapp för att gå vidare...");
                    Console.ReadKey();
                }
            }
        }
    }
}

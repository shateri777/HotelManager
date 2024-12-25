namespace HotellApp_Databasteknik_2.Utilities
{
    public class DisplayMenus
    {
        private const string MainMenuHeader = "Välkommen till Hotell appen!";
        private const string CustomerMenuHeader = "Kundmeny";
        private const string RoomMenuHeader = "Rum meny";
        private const string BookingMenuHeader = "Bokningsmeny";

        private const string MainMenuOptions = "1. Kunder\n2. Rum\n3. Bokningar\n0. Avsluta";
        private const string CustomerMenuOptions = "1. Lägg till en kund\n2. Läs av alla kunder\n3. Uppdatera en kund\n4. Ta bort en kund\n0. Huvudmenyn";
        private const string RoomMenuOptions = "1. Lägg till ett rum\n2. Läs av alla rum\n3. Uppdatera ett rum\n4. Ta bort ett rum\n0. Huvudmenyn";
        private const string BookingMenuOptions = "1. Lägg till en bokning\n2. Läs av alla bokningar\n3. Uppdatera en bokning\n4. Ta bort en bokning\n0. Huvudmenyn";

        public void MainMenu()
        {
            DisplayMenu(MainMenuHeader, MainMenuOptions);
        }
        public void CustomerMenu()
        {
            DisplayMenu(CustomerMenuHeader, CustomerMenuOptions);
        }
        public void RoomMenu()
        {
            DisplayMenu(RoomMenuHeader, RoomMenuOptions);
        }
        public void BookingMenu()
        {
            DisplayMenu(BookingMenuHeader, BookingMenuOptions);
        }
        private void DisplayMenu(string header, string options)
        {
            Console.Clear();
            Console.WriteLine(header);
            Console.WriteLine(options);
        }
    }
}

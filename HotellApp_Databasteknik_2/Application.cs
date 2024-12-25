using HotellApp_Databasteknik_2.Data;
using HotellApp_Databasteknik_2.Utilities;
using HotellApp_Databasteknik_2.Utilities.Menu_Details;
namespace HotellApp_Databasteknik_2
{
    public class Application
    {
        private readonly DisplayMenus _displayMenus;
        private readonly MenuControls _menuControls;
        private readonly Data_Initializer _dataInitializer;
        public Application(DisplayMenus displayMenus, MenuControls menuControls, Data_Initializer dataInitializer)
        {
            _displayMenus = displayMenus;
            _menuControls = menuControls;
            _dataInitializer = dataInitializer;
            
        }
        public void Run()
        {
            _dataInitializer.MigrateAndSeed();
            while (true)
            {
                try
                {
                    _displayMenus.MainMenu();
                    byte userInputForMainMenu = Convert.ToByte(Console.ReadLine());
                    _menuControls.MainMenu(userInputForMainMenu);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
    }
}

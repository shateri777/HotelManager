using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace HotellApp_Databasteknik_2.Utilities.Calendar
{
    public class CalendarForBooking
    {
        public DateTime ShowCalendar()
        {
            DateTime currentDate = DateTime.Now;
            DateTime selectedDate = new DateTime(currentDate.Year, currentDate.Month, 1);

            while (true)
            {
                Console.Clear();
                RenderCalendar(selectedDate);

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        selectedDate = selectedDate.AddDays(1);
                        break;
                    case ConsoleKey.LeftArrow:
                        selectedDate = selectedDate.AddDays(-1);
                        break;
                    case ConsoleKey.UpArrow:
                        selectedDate = selectedDate.AddDays(-7);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedDate = selectedDate.AddDays(7);
                        break;
                    case ConsoleKey.Enter:
                        if (selectedDate < DateTime.Now)
                        {
                            Console.ForegroundColor = Color.Red;
                            Console.WriteLine("Du kan inte välja dagens datum eller något tidigare datum.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        else
                        {
                            AnsiConsole.MarkupLine($"\nDu valde: [green]{selectedDate:yyyy-MM-dd}[/]");
                            Console.ReadKey();
                            return selectedDate;
                        };
                        continue;
                }
            }
        }
        public void RenderCalendar(DateTime selectedDate)
        {
            var calendar = new StringWriter();
            calendar.WriteLine($"[red]{selectedDate:MMMM}[/]".ToUpper());
            calendar.WriteLine("Mån  Tis  Ons  Tor  Fre  Lör  Sön");
            calendar.WriteLine("─────────────────────────────────");

            DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
            int startDay = (int)firstDayOfMonth.DayOfWeek;
            startDay = startDay == 0 ? 6 : startDay - 1;

            for (int i = 0; i < startDay; i++)
            {
                calendar.Write("     ");
            }
            for (int day = 1; day <= daysInMonth; day++)
            {
                if (day == selectedDate.Day)
                {
                    calendar.Write($"[green]{day,2}[/]   ");
                }
                else
                {
                    calendar.Write($"{day,2}   ");
                }

                if ((startDay + day) % 7 == 0)
                {
                    calendar.WriteLine();
                }
            }
            var panel = new Panel(calendar.ToString())
            {
                Border = BoxBorder.Double,
                Header = new PanelHeader($"[red]{selectedDate:yyyy}[/]", Justify.Center)
            };
            AnsiConsole.Write(panel);
            Console.WriteLine();
            AnsiConsole.MarkupLine("Använd piltangenter för att navigera och [green]Enter[/] för att välja.");
        }
    }
}

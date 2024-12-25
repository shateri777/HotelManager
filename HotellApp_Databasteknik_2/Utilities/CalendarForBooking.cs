using Spectre.Console;
namespace HotellApp_Databasteknik_2.Utilities
{
    public class CalendarForBooking
    {
        private readonly StringWriter _stringWriter;
        public CalendarForBooking(StringWriter stringWriter)
        {
            _stringWriter = stringWriter;
        }
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
                            Console.WriteLine("Du kan inte välja dagens datum eller något innan dagens datum.");
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
            _stringWriter.WriteLine($"[red]{selectedDate:MMMM}[/]".ToUpper());
            _stringWriter.WriteLine("Mån  Tis  Ons  Tor  Fre  Lör  Sön");
            _stringWriter.WriteLine("─────────────────────────────────");

            DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
            int startDay = (int)firstDayOfMonth.DayOfWeek;
            startDay = startDay == 0 ? 6 : startDay - 1;

            for (int i = 0; i < startDay; i++)
            {
                _stringWriter.Write("     ");
            }


            for (int day = 1; day <= daysInMonth; day++)
            {
                if (day == selectedDate.Day)
                {
                    _stringWriter.Write($"[green]{day,2}[/]   ");
                }
                else
                {
                    _stringWriter.Write($"{day,2}   ");
                }

                if ((startDay + day) % 7 == 0)
                {
                    _stringWriter.WriteLine();
                }
            }

            var panel = new Panel(_stringWriter.ToString())
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

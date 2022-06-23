using System;
using Modals;

namespace Lab4 {
    class Program {
        static void Main(string[] args) {
            AnalogClock AClock = new AnalogClock();
            ClockHandler Handler = new ClockHandler(AClock);

            Console.WriteLine("==================== Аналоговые часы ====================");
            Console.WriteLine("Текущее время: " + AClock.Time);
            Console.Write("Введите кол-во часов: ");
            int.TryParse(Console.ReadLine(), out int Hours);
            Console.Write("Введите кол-во минут: ");
            int.TryParse(Console.ReadLine(), out int Minutes);
            Console.Write("Введите кол-во секунд: ");
            int.TryParse(Console.ReadLine(), out int Seconds);
            try {
                Handler.Hours = Hours;
                Handler.Minutes = Minutes;
                Handler.Seconds = Seconds;
            }
            catch(ArgumentOutOfRangeException e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            Console.WriteLine("Текущее время: " + AClock.Time);

            Console.ReadKey();

            DigitalClock DClock = new DigitalClock();
            Handler = new ClockHandler(DClock);

            Console.WriteLine("==================== Цифровые часы ====================");
            Console.WriteLine("Текущее время: " + DClock.Time);
            Console.Write("Введите кол-во часов: ");
            int.TryParse(Console.ReadLine(), out int Hours_2);
            Console.Write("Введите кол-во минут: ");
            int.TryParse(Console.ReadLine(), out int Minutes_2);
            Console.Write("Введите кол-во секунд: ");
            int.TryParse(Console.ReadLine(), out int Seconds_2);
            try {
                Handler.Hours = Hours_2;
                Handler.Minutes = Minutes_2;
                Handler.Seconds = Seconds_2;
            }
            catch (ArgumentOutOfRangeException e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            Console.WriteLine("Текущее время: " + DClock.Time);

            Console.ReadKey();
        }
    }
}

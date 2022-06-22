using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Handler.SetHours(Hours);
            Handler.SetMinutes(Minutes); 
            Handler.SetSeconds(Seconds);
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
            Handler.SetHours(Hours_2);
            Handler.SetMinutes(Minutes_2);
            Handler.SetSeconds(Seconds_2);
            Console.WriteLine("Текущее время: " + DClock.Time);

            Console.ReadKey();
        }
    }
}

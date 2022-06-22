using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    public class СonsoleApplication {
        public void Print_menu(List<string> menu, int Num)  {
            for (int i = 0; i < menu.Count; i++) {
                if (i + 1 == Num)
                    Color_Print_Green(menu[i]);
                else
                    Console.WriteLine(menu[i]);
            }
        }
        public void Color_Print_Green(string str) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public int menu_navigation(List<string> menu) {
            int Num = 1;
            bool Bool = true;
            int count = 0;
            ConsoleKeyInfo key;
            while (Bool) {
                key = Console.ReadKey(true);
                count++;
                if (count == 1)
                    Console.Clear();
                switch (key.Key) {
                    case ConsoleKey.UpArrow:
                        {
                            Num--;
                            if (Num < 1)
                                Num = menu.Count;
                            Console.SetCursorPosition(0, 0);
                            Print_menu(menu, Num);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            Num++;
                            if (Num > menu.Count)
                                Num = 1;
                            Console.SetCursorPosition(0, 0);
                            Print_menu(menu, Num);
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            Bool = false;
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Print_menu(menu, Num);
                            break;
                        }
                }
            }
            return Num;
        }
    }
}

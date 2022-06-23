using System;
using System.Collections.Generic;

namespace Lab5 {
    public class ConsoleApplication {
        public void PrintGreen(string str) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public void PrintMenu(List<string> menu, int num) {
            for (int i = 0; i < menu.Count; i++) {
                if (i + 1 == num)
                    PrintGreen(menu[i]);
                else
                    Console.WriteLine(menu[i]);
            }
        }

        public int MenuNavigation(List<string> menu) {
            int Num = 1;
            bool Bool = true;
            int count = 0;
            ConsoleKeyInfo key;
            while (Bool) {
                key = Console.ReadKey(true);
                count++;
                if (count == 1)
                    Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            Num--;
                            if (Num < 1)
                                Num = menu.Count;
                            Console.SetCursorPosition(0, 0);
                            PrintMenu(menu, Num);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            Num++;
                            if (Num > menu.Count)
                                Num = 1;
                            Console.SetCursorPosition(0, 0);
                            PrintMenu(menu, Num);
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
                            PrintMenu(menu, Num);
                            break;
                        }
                }
            }
            return Num;
        }
    }
}

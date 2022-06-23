using System;
using System.Collections.Generic;
using Modals;

namespace Lab5 {
    class Program {
        static void Main(string[] args) {
            List<string> Menu = new List<string>(){
                "Следующий цвет",
                "Предыдущий цвет",
                "Увеличить фигуру",
                "Уменьшить фигуру",
                "Нарисовать квадрат",
                "Нарисовать треугольник",
                "Откатить изменения"
            };

            Application Canvas = new Application();
            Canvas.SetSquare();

            ConsoleApplication ConsoleMenu = new ConsoleApplication();
            CmdList cmd = new CmdList(Canvas);

            int num;
            while (true) {
                Console.ForegroundColor = (ConsoleColor)Canvas.Editor.Figure.Color;
                Console.WriteLine(Canvas.Draw());
                Console.ResetColor();

                ConsoleMenu.PrintMenu(Menu, 1);
                num = ConsoleMenu.MenuNavigation(Menu);
                Console.Clear();
                cmd[num]();
            }
        }
    }
}

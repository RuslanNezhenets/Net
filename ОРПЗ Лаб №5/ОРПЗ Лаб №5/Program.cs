using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modals.Figures;
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
            Console.WriteLine(Canvas.Draw());

            ConsoleApplication ConsoleMenu = new ConsoleApplication();
            CmdList cmd = new CmdList(Canvas);

            int num;
            while (true) {
                ConsoleMenu.Print_menu(Menu, 1);
                num = ConsoleMenu.menu_navigation(Menu);
                Console.Clear();
                cmd[num]();
                Console.ForegroundColor = (ConsoleColor)Canvas.Editor.figure.Color;
                Console.WriteLine(Canvas.Draw());
                Console.ResetColor();
            }
        }
    }
}

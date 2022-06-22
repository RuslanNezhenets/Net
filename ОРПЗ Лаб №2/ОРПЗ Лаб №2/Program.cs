using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Lab2 {
    partial class Program{
        static void Main(string[] args){
            List<string> FirstMenu = new List<string>(){
                "Запросы",
                "Вывести содержимое файлов",
                "Добавить новые данные"
            };

            Console.InputEncoding = Encoding.GetEncoding(1251);

            ConsoleApplication ConsoleMenu = new ConsoleApplication();
            FirstMenuMethods FirstMenuMethods = new FirstMenuMethods();

            Console.Clear();
            int num;
            while(true){
                ConsoleMenu.Print_menu(FirstMenu, 1);
                num = ConsoleMenu.menu_navigation(FirstMenu);

                Console.Clear();

                MethodInfo[] Methods = typeof(FirstMenuMethods).GetMethods(BindingFlags.Instance |
                BindingFlags.Public | BindingFlags.DeclaredOnly);

                Methods[num - 1].Invoke(FirstMenuMethods, null);
            }
        }
    }
}
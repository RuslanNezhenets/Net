using System;
using System.Collections.Generic;
using System.Reflection;
using Modal;
using ConsoleAddendum;

namespace Lab1{
    class Program{
        static void PrintLine(){
            Console.WriteLine("============================================================");
        }

        static void Main(){
            List<string> Menu = new List<string>() {
                "Запрос №1 - Простая выборка елементов",
                "Запрос №2 - Выборка отдельного поля",
                "Запрос №3 - Сортировка",
                "Запрос №4 - Сортировка с использованием Max",
                "Запрос №5 - Сотрировка с использованием методов расширения",
                "Запрос №6 - Cross Join и Group Join",
                "Запрос №7 - Использование Join для слаженных ключей",
                "Запрос №8 - Distinct - для объектов",
                "Запрос №9 - Intersect - пересечение множеств для объектов",
                "Запрос №10 - Aggregate - агрегирование значений",
                "Запрос №11 - Except - разница множеств для объектов",
                "Запрос №12 - Группировка",
                "Запрос №13 - Группировка - Any и Union",
                "Запрос №14 - Concat - объденение с повторением",
                "Запрос №15 - Первый элемент в выборке по заданому параметру"
            };
            List<string> MenuItemsDescription = new List<string>(){
                "Запрос №1 - Вывод информации про все кинотеатры",
                "Запрос №2 - Вывод информации только про количество мест",
                "Запрос №3 - Кинотеатры ёмкостью 100 и более людей для просмотра " +
                    "широкофарматных фильмов\nили с наличием стереоформатного оборудывания",
                "Запрос №4 - Вывод информации про кинотеатры для просмотра видеофильмов\n" +
                    "с максимальным количеством мест",
                "Запрос №5 - Сортировка и использованием расшириваемых методов\n" +
                    "по количеству мест (дополнительно по году) для просмотра видеофильмов",
                "Запрос №6 - Пары кинатеатров с одинаковым количеством мест",
                "Запрос №7 - Поиск одинаковых кинотеатров в двух списках " +
                    "по названию и количеству мест",
                "Запрос №8 - Вывод уникальных кинотеатров",
                "Запрос №9 - Вывод кинотеатров, которые есть в каждом из указанных списков",
                "Запрос №10 - Создание нового кинотеатра с количеством мест равным\n" +
                    "сумме кол-в мест кинотеатров большим или равным 100",
                "Запрос №11 - Кинотеатры из первого списка, которых нету во втором",
                "Запрос №12 - Группировка за рангом",
                "Запрос №13 - Группировка по рангу (в каждом ранге должен быть " +
                    "хотя бы один кинотеатр 200+ мест",
                "Запрос №14 - Вывод всех кинотеатров в списках (с повторами)",
                "Запрос №15 - Вывод первого попавшегося " +
                        "кинотеатра для просмотра широкоформатных фильмов"
            };

            СonsoleApplication ConsoleMenu = new СonsoleApplication();

            Querys querys = new Querys();

            MethodInfo[] Methods = typeof(Querys).GetMethods(BindingFlags.Instance |
                BindingFlags.Public | BindingFlags.DeclaredOnly);

            int num;

            while (true){
                ConsoleMenu.Print_menu(Menu, 1);
                num = ConsoleMenu.menu_navigation(Menu);

                Console.Clear();

                List<CinemaFullInfo> queryOutput = 
                    (List<CinemaFullInfo>)Methods[num - 1].Invoke(querys, null);

                ConsoleMenu.Color_Print_Green(MenuItemsDescription[num - 1]);
                PrintLine();

                foreach(CinemaFullInfo x in queryOutput){
                    Console.WriteLine(x);
                    PrintLine();
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}

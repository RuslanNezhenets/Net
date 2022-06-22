using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace Lab2{
    public class FirstMenuMethods{
        public void Create(){
            List<string> Menu = new List<string>() {
                "Запрос №1 - Простая выборка елементов",
                "Запрос №2 - Выборка отдельного поля",
                "Запрос №3 - Выборка по количеству мест",
                "Запрос №4 - Сортировка с использованием Max",
                "Запрос №5 - Сотрировка с использованием методов расширения",
                "Запрос №6 - Cross Join",
                "Запрос №7 - Использование Join для слаженных ключей",
                "Запрос №8 - Distinct - для объектов",
                "Запрос №9 - Intersect - пересечение множеств для объектов",
                "Запрос №10 - Aggregate - агрегирование значений",
                "Запрос №11 - Except - разница множеств для объектов",
                "Запрос №12 - Группировка",
                "Запрос №13 - Группировка - Any и Union",
                "Запрос №14 - Concat - объденение с повторением",
                "Запрос №15 - Первый элемент в выборке"
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
                        "кинотеатра для просмотра широкоформатных фильмов",
            };

            QueryPrint queryPrint = new QueryPrint();
            ConsoleApplication ConsoleMenu = new ConsoleApplication();
            OutputData Output = new OutputData();
            
            MethodInfo[] Methods = typeof(QueryPrint).GetMethods(BindingFlags.Instance |
            BindingFlags.Public | BindingFlags.DeclaredOnly);

            bool temp = true;
            int num;
            while (temp){
                ConsoleMenu.Print_menu(Menu, 1);
                num = ConsoleMenu.menu_navigation(Menu);

                Console.Clear();

                if (num == 0)
                    temp = false;
                else{
                    ConsoleMenu.Color_Print_Green(MenuItemsDescription[num - 1]);
                    Output.PrintLine();
                    Methods[num - 1].Invoke(queryPrint, null);

                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void PrintData(){
            string[] dirs = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml");

            List<string> Dirs = new List<string>();
            for (int i = 0; i < dirs.Length; i++){
                string File = dirs[i].Substring(dirs[i].LastIndexOf("\\") + 1);
                Dirs.Add(File);
            }

            bool temp = true;
            int num;
            ConsoleApplication ConsoleMenu = new ConsoleApplication();
            OutputData Output = new OutputData();
            while (temp){
                ConsoleMenu.Print_menu(Dirs, 1);
                num = ConsoleMenu.menu_navigation(Dirs);
                Console.Clear();

                if (num == 0)
                    temp = false;
                else{
                    if (Dirs[num - 1] == "Ranks.xml"){
                        XDocument Ranks = XDocument.Load(Dirs[num - 1]);
                        foreach (XElement node in Ranks.Root.Elements("rank")){
                            Output.PrintRank(node);
                            Console.WriteLine("============================================================");
                        }
                    } else {
                        XDocument Ranks = XDocument.Load(Dirs[num - 1]);
                        foreach (XElement node in Ranks.Root.Elements("cinema")) {
                            Output.PrintCinema(node);
                            Console.WriteLine("============================================================");
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        public void FillFile(){
            InputData Input = new InputData();
            ConsoleReader reader = new ConsoleReader();

            Console.Write("Введите имя файла (без расширения): ");
            string FileName = Console.ReadLine();
            Console.Write("Введите количество записей, которые хотите создать: ");
            int count = int.Parse(Console.ReadLine());

            if (FileName != "Ranks"){
                for (int i = 0; i < count; i++){
                    Console.WriteLine("===============================");
                    Cinema cinema = reader.CinemaRead();
                    Input.InputCinema(FileName + ".xml", cinema);
                }
            }
            else{
                for (int i = 0; i < count; i++){
                    Console.WriteLine("===============================");
                    string RankDescription = reader.RankRead();
                    Input.InputRank(FileName + ".xml", RankDescription);
                }
            }
            Console.Clear();
        }
    }
}

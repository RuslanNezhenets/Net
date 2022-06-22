using System;
using System.Collections.Generic;
namespace Lab2 {
    class ConsoleReader {
        public Cinema CinemaRead(){
            Console.Write("Введите название кинотеатра: ");
            string name = Console.ReadLine();
            Console.Write("Введите количество мест: ");
            string capacityString = Console.ReadLine();
            Console.Write("Введите год создания: ");
            string yearConstructionString = Console.ReadLine();
            Console.Write("Введите id ранга: ");
            string rankIdString = Console.ReadLine();

            int capacity = 0;
            int yearConstruction = 1970;
            int rankId = 0;
            if (int.TryParse(capacityString, out int result_1)) capacity = result_1;
            if (int.TryParse(yearConstructionString, out int result_2)) yearConstruction = result_2;
            if (int.TryParse(rankIdString, out int result_3)) rankId = result_3;

            return new Cinema() { Name = name, Capacity = capacity,
                YearConstruction = yearConstruction, RankId = rankId };
        }

        public string RankRead(){
            Console.Write("Введите описание ранга: ");
            return Console.ReadLine();
        }
    }
}

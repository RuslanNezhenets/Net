using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Lab2{
    public class OutputData{
        public void PrintCinema(XElement node){
            if (node.Element("name") != null){
                string Name = node.Element("name").Value;
                Console.WriteLine("Кинотеатр: " + Name);
            }
            if (node.Element("capacity") != null){
                int Capacity = int.Parse(node.Element("capacity").Value);
                Console.WriteLine("Количество мест: " + Capacity);
            }
            if (node.Element("yearConstruction") != null){
                int YearConstruction = int.Parse(node.Element("yearConstruction").Value);
                Console.WriteLine("Год создания: " + YearConstruction);
            }
            if (node.Element("rankId") != null && node.Element("rankDescription") == null){
                int RankDescription = int.Parse(node.Element("rankId").Value);
                Console.WriteLine("Id ранга кинотеатра: " + RankDescription);
            }
            if (node.Element("rankDescription") != null){
                string RankDescription = node.Element("rankDescription").Value;
                Console.WriteLine("Ранг кинотеатра: " + RankDescription);
            }
        }
        public void PrintRank(XElement node){
            if (node.Element("id") != null){
                int RankId = int.Parse(node.Element("id").Value);
                Console.WriteLine("Id ранга кинотеатра: " + RankId);
            }
            if (node.Element("rankDescription") != null){
                string RankDescription = node.Element("rankDescription").Value;
                Console.WriteLine("Описание ранга: " + RankDescription);
            }
        }

        public void PrintDictionary(Dictionary<string, List<XElement>> Dictionary) {
            foreach (var node in Dictionary) {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(node.Key);
                Console.ResetColor();
                Console.WriteLine();

                foreach (XElement cinema in node.Value) {
                    PrintCinema(cinema);
                    PrintLine();
                }
            }
        }

        public void PrintLine() {
            Console.WriteLine("============================================================");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modals;
using Modals.Planets;

namespace Lab3 {
    class Program {
        static void PrintLine() {
            Console.WriteLine("---------------------------------------------");
        }

        static void Main(string[] args) {
            СonsoleApplication ConsoleMenu = new СonsoleApplication();
            PlanetCreator Creator = new PlanetCreator();
            
            List<string> Menu = new List<string>(Enum.GetNames(typeof(PlanetName)));

            int num;
            while (true) {
                ConsoleMenu.Print_menu(Menu, 1);
                num = ConsoleMenu.menu_navigation(Menu);

                Console.Clear();

                Planet Planet = Creator.GetPlanet((PlanetName)num);

                Console.WriteLine("=========================== " + ((PlanetName)num).ToString()
                    + " ===========================");

                Console.WriteLine(Planet);
                if(Planet.Moons.Any())
                    Console.WriteLine("=========================== Спутники ===========================");
                foreach (Moon moon in Planet.Moons){
                    Console.WriteLine(moon);
                    PrintLine();
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

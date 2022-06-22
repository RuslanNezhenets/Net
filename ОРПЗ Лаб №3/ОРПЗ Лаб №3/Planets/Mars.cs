using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Planets {
    public class Mars: Planet {
        private static Mars instance;
        private Mars() { }
        public override double Weight { get; } = 0.642;
        public override int Diameter { get; } = 6794;
        public override int Density { get; } = 3933;
        public override double Gravity { get; } = 3.7;
        public override double DayLength { get; } = 24.7;
        public override int Temperature { get; } = -65;
        public override bool RingSystem { get; } = false;
        public override IEnumerable<Moon> Moons { get; } = new List<Moon>(){
            new Moon(){Name = "Деймос", OrbitRadius = 23.459, Diameter = 12.4,
                Discoverer = "Холл", YearDiscovery = 1877,
                Pecaliarities = "Один из самых маленьких"},
            new Moon(){Name = "Фобос", OrbitRadius = 9.378, Diameter = 22.533,
                Discoverer = "Холл", YearDiscovery = 1877,
                Pecaliarities = "Орбита уменьшается из-за торможения об атмосферу"}
        };
        public static Mars GetInstance() {
            if (instance == null) {
                instance = new Mars();
            }
            return instance;
        }
    }
}

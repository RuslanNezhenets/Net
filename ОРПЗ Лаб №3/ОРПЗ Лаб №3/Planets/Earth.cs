using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Planets {
    public class Earth : Planet {
        private static Earth instance;
        private Earth() { }
        public override double Weight { get; } = 5.97;
        public override int Diameter { get; } = 12756;
        public override int Density { get; } = 5515;
        public override double Gravity { get; } = 9.8;
        public override double DayLength { get; } = 24;
        public override int Temperature { get; } = 15;
        public override bool RingSystem { get; } = false;
        public override IEnumerable<Moon> Moons { get; } = new List<Moon>() {
            new Moon() { Name = "Луна", OrbitRadius = 384.4, Diameter = 3474.8,
                Discoverer = "Луна-2", YearDiscovery = 1959 ,
                Pecaliarities = "Многократное увеличение орбиты из-за приливов.\n" +
                "Образование столь крупной Луны непонятно" }
        };

        public static Earth GetInstance() {
            if(instance == null) {
                instance = new Earth();
            }
            return instance;
        }
    }
}

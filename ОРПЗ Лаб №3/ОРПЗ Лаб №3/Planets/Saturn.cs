using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Planets {
    public class Saturn : Planet {
        private static Saturn instance;
        private Saturn() { }
        public override double Weight { get; } = 568;
        public override int Diameter { get; } = 120536;
        public override int Density { get; } = 687;
        public override double Gravity { get; } = 9;
        public override double DayLength { get; } = 10.7;
        public override int Temperature { get; } = -140;
        public override bool RingSystem { get; } = true;
        public override IEnumerable<Moon> Moons { get; } = new List<Moon>(){
            new Moon(){Name = "Пан", OrbitRadius = 133.6, Diameter = 20,
                Discoverer = "Террил", YearDiscovery = 1980,
                Pecaliarities = "Один из пяти спутников за внешним краем кольца А"},
            new Moon(){Name = "Феба", OrbitRadius = 12954, Diameter = 213,
                Discoverer = "Пиккеринг", YearDiscovery = 1898,
                Pecaliarities = "Спутник с обратным вращением"}
        };

        public static Saturn GetInstance() {
            if (instance == null) {
                instance = new Saturn();
            }
            return instance;
        }
    }
}

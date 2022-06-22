using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Planets {
    public class Jupiter : Planet {
        private static Jupiter instance;
        private Jupiter() { }
        public override double Weight { get; } = 1899;
        public override int Diameter { get; } = 142984;
        public override int Density { get; } = 1326;
        public override double Gravity { get; } = 23.1;
        public override double DayLength { get; } = 9.9;
        public override int Temperature { get; } = -110;
        public override bool RingSystem { get; } = true;
        public override IEnumerable<Moon> Moons { get; } = new List<Moon>() {
            new Moon() { Name = "Метис", OrbitRadius = 128.2, Diameter = 40,
                Discoverer = "Синнотт", YearDiscovery = 1979,
                Pecaliarities = "Спутник на внешнем крае кольца Юпитера"},
            new Moon() { Name = "Адрастея", OrbitRadius = 128.5, Diameter = 16.4,
                Discoverer = "Джунт, Дэниелсон", YearDiscovery = 1979,
                Pecaliarities = "Спутник на внешнем крае кольца Юпитера"},
        };
        public static Jupiter GetInstance() {
            if (instance == null) {
                instance = new Jupiter();
            }
            return instance;
        }
    }
}

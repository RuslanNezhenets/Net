using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Planets {
    public class Uranus : Planet {
        private static Uranus instance;
        private Uranus() { }
        public override double Weight { get; } = 86.8;
        public override int Diameter { get; } = 51118;
        public override int Density { get; } = 1270;
        public override double Gravity { get; } = 8.7;
        public override double DayLength { get; } = 17.2;
        public override int Temperature { get; } = -195;
        public override bool RingSystem { get; } = true;
        public override IEnumerable<Moon> Moons { get; } = new List<Moon>(){
            new Moon(){Name = "Корде лия", OrbitRadius = 49.771, Diameter = 26,
                Discoverer = "Вояджер-2", YearDiscovery = 1986,
                Pecaliarities = "Расположен внутри колец"},
            new Moon(){Name = "Офелия", OrbitRadius = 53.796, Diameter = 30,
                Discoverer = "Вояджер-2", YearDiscovery = 1986,
                Pecaliarities = "Расположен внутри колец"}
        };
        public static Uranus GetInstance() {
            if (instance == null) {
                instance = new Uranus();
            }
            return instance;
        }
    }
}

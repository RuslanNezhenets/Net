using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Planets {
    public class Neptune : Planet {
        private static Neptune instance;
        private Neptune() { }
        public override double Weight { get; } = 102;
        public override int Diameter { get; } = 49528;
        public override int Density { get; } = 1638;
        public override double Gravity { get; } = 11;
        public override double DayLength { get; } = 16.1;
        public override int Temperature { get; } = -200;
        public override bool RingSystem { get; } = true;
        public override IEnumerable<Moon> Moons { get; } = new List<Moon>() {
            new Moon() { Name = "Наяда", OrbitRadius = 48.23, Diameter = 58,
                Discoverer = "Вояджер-2", YearDiscovery = 1989,
                Pecaliarities = "Расположен внутри колец, возможно, в зоне гравитационной неустойчивости"},
            new Moon() { Name = "Таласса", OrbitRadius = 50.07, Diameter = 80,
                Discoverer = "Вояджер-2", YearDiscovery = 1989,
                Pecaliarities = "Расположен внутри колец, возможно, в зоне гравитационной неустойчивости"},
            new Moon() { Name = "Деспина", OrbitRadius = 52.53, Diameter = 148,
                Discoverer = "Вояджер-2", YearDiscovery = 1989,
                Pecaliarities = "Расположен внутри колец, возможно, в зоне гравитационной неустойчивости"}
        };

        public static Neptune GetInstance() {
            if (instance == null) {
                instance = new Neptune();
            }
            return instance;
        }
    }
}

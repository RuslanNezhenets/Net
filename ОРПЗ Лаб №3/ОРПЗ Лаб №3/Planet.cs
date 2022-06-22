using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals {
    public abstract class Planet {
        public abstract double Weight { get; }
        public abstract int Diameter { get; }
        public abstract int Density { get; }
        public abstract double Gravity { get; }
        public abstract double DayLength { get; }
        public abstract int Temperature { get; }
        public abstract bool RingSystem { get; }
        public virtual IEnumerable<Moon> Moons { get; } = new List<Moon>();
        public override string ToString() {
            return "Масса (10^24 кг): " + Weight
                + "\nДиаметр (км): " + Diameter
                + "\nПлотность (кг/м^3): " + Density
                + "\nПритяжение (м/с^2*кг): " + Gravity
                + "\nПродолжительность дня (часы): " + DayLength
                + "\nТемпература (k): " + Temperature
                + "\nКольцевая система: " + (RingSystem ? "Да" : "Нет");
        }
    }
}

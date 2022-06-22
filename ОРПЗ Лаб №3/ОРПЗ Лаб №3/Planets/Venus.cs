using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Planets {
    public class Venus : Planet {
        private static Venus instance;
        private Venus() { }
        public override double Weight { get; } = 4.87;
        public override int Diameter { get; } = 12104;
        public override int Density { get; } = 5243;
        public override double Gravity { get; } = 8.9;
        public override double DayLength { get; } = 2802;
        public override int Temperature { get; } = 464;
        public override bool RingSystem { get; } = false;
        public static Venus GetInstance() {
            if (instance == null) {
                instance = new Venus();
            }
            return instance;
        }
    }
}

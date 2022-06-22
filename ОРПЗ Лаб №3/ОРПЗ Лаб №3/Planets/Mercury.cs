using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Planets {
    public class Mercury : Planet {
        private static Mercury instance;
        private Mercury() { }
        public override double Weight { get; } = 0.33;
        public override int Diameter { get; } = 4879;
        public override int Density { get; } = 5427;
        public override double Gravity { get; } = 3.7;
        public override double DayLength { get; } = 4222.6;
        public override int Temperature { get; } = 167;
        public override bool RingSystem { get; } = false;
        public static Mercury GetInstance() {
            if (instance == null) {
                instance = new Mercury();
            }
            return instance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals {
    public class Moon {
        public string Name { get; set; }
        public double OrbitRadius { get; set; }
        public double Diameter { get; set; }
        public string Discoverer { get; set; }
        public int YearDiscovery { get; set; }
        public string Pecaliarities { get; set; }

        public override string ToString() {
            return "Название: " + Name
                + "\nРадиус орбиты (тыс. км): " + OrbitRadius
                + "\nДиаметр спутника (км): " + Diameter
                + "\nОткрыватель: " + Discoverer
                + "\nГод обнаружения: " + YearDiscovery
                + "\nОсобенности:" + Pecaliarities;
        }
    }

}

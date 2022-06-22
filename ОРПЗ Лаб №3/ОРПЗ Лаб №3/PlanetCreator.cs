using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modals.Planets;

namespace Modals {
    public class PlanetCreator {
        public Planet GetPlanet(PlanetName name) {
            switch (name) {
                case PlanetName.Mercury:
                    return Mercury.GetInstance();
                case PlanetName.Venus:
                    return Venus.GetInstance();
                case PlanetName.Mars:
                    return Mars.GetInstance();
                case PlanetName.Jupiter:
                    return Jupiter.GetInstance();
                case PlanetName.Saturn:
                    return Saturn.GetInstance();
                case PlanetName.Uranus:
                    return Uranus.GetInstance();
                case PlanetName.Neptune:
                    return Neptune.GetInstance();
                default:
                    return Earth.GetInstance();
            }
        }
    }
}

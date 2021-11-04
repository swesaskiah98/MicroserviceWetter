using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceAPIWetter.Model {
    public class WetterData {
        public DateTime datum { get; set; }
        public double minTemp { get; set; } // minimale Tagestemperatur in °C
        public double maxTemp { get; set; } // maximale Tagestemperatur in °C
        public int niederschlag { get; set; } //Niederschlag in mm

        public WetterData () {

        }

        public WetterData (DateTime datum, double minTemp, double maxTemp, int niederschlag) {
            this.datum = datum;
            this.minTemp = minTemp;
            this.maxTemp = maxTemp;
            this.niederschlag = niederschlag;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceAPIWetter.Model {
    public class WetterData {
        public DateTime datum { get; set; }
        public double temperatur { get; set; }
        public bool niederschlag { get; set; }
    }
}

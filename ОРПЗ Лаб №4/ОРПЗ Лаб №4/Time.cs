using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals {
    public class Time {
        public int Hours { get; set; } = DateTime.Now.Hour;
        public int Minutes { get; set; } = DateTime.Now.Minute;
        public int Seconds { get; set; } = DateTime.Now.Second;
        public override string ToString() {
            string output = "";
            if (Hours < 10)
                output += "0";
            output += Hours.ToString();
            output += ":";
            if (Minutes < 10)
                output += "0";
            output += Minutes.ToString();
            output += ":";
            if (Seconds < 10)
                output += "0";
            output += Seconds.ToString();

            return output;
        }
    }
}

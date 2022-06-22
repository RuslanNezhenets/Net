using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals {
    public class DigitalClock: IClock {
        public Time Time { get; } = new Time();
        public void AddHour() {
            Time.Hours++;
            if (Time.Hours == 24)
                Time.Hours = 0;
        }
        public void AddMinute() {
            Time.Minutes++;
            if (Time.Minutes == 60)
                Time.Minutes = 0;
        }
        public void AddSecond() {
            Time.Seconds++;
            if (Time.Seconds == 60)
                Time.Seconds = 0;
        }
    }
}

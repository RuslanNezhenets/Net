using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals {
    public class ClockHandler {
        private IClock clock;
        public Time Time { get { return clock.Time; } }
        public ClockHandler(IClock Clock) {
            this.clock = Clock;
        }
        public void SetHours(int hours) {
            if (hours < 0 || hours >= 24)
                return;
            int temp = hours - clock.Time.Hours;
            if (temp < 0)
                temp += 24;
            for (int i = 0; i < temp; i++)
                clock.AddHour();
        }
        public void SetMinutes(int minutes) {
            if (minutes < 0 || minutes >= 60)
                return;
            int temp = minutes - clock.Time.Minutes;
            if (temp < 0)
                temp += 60;
            for (int i = 0; i < temp; i++)
                clock.AddMinute();
        }
        public void SetSeconds(int seconds) {
            if (seconds < 0 || seconds >= 60)
                return;
            int temp = seconds - clock.Time.Seconds;
            if (temp < 0)
                temp += 60;
            for (int i = 0; i < temp; i++)
                clock.AddSecond();
        }
    }
}

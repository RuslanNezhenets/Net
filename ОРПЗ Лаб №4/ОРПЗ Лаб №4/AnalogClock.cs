using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals {
    public class AnalogClock: IClock {
        public Time Time {
            get {
                return new Time() {
                    Hours = (HourHand / 15)%12,
                    Minutes = MinuteHand / 6,
                    Seconds = SecondHand / 6
                };
            }
        }
        public int HourHand { get; set; } = (DateTime.Now.Hour%12) * 15;
        public int MinuteHand { get; set; } = DateTime.Now.Minute * 6;
        public int SecondHand { get; set; } = DateTime.Now.Second * 6;
        public void AddHour() {
            HourHand += 15;
            if (HourHand == 360)
                HourHand = 0;
        }
        public void AddMinute() {
            MinuteHand += 6;
            if (MinuteHand == 360)
                MinuteHand = 0;
        }
        public void AddSecond() {
            SecondHand += 6;
            if (SecondHand == 360)
                SecondHand = 0;
        }
    }
}

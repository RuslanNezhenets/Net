using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals {
    public class ClockHandler {
        private readonly IClock _clock;
        public Time Time { get { return _clock.Time; } }
        public ClockHandler(IClock Clock) {
            _clock = Clock;
        }
        public int Hours {
            set {
                if (value < 0 || value >= 24)
                    throw new ArgumentOutOfRangeException(nameof(value), "Невереное кол-во часов");
                int temp = value - _clock.Time.Hours;
                if (temp < 0)
                    temp += 24;
                for (int i = 0; i < temp; i++)
                    _clock.AddHour();
            }
        }
        public int Minutes {
            set {
                if (value < 0 || value >= 60)
                    throw new ArgumentOutOfRangeException(nameof(value), "Невереное кол-во минут");
                int temp = value - _clock.Time.Minutes;
                if (temp < 0)
                    temp += 60;
                for (int i = 0; i < temp; i++)
                    _clock.AddMinute();
            }
        }
        public int Seconds {
            set {
                if (value < 0 || value >= 60)
                    throw new ArgumentOutOfRangeException(nameof(value), "Невереное кол-во секунд");
                int temp = value - _clock.Time.Seconds;
                if (temp < 0)
                    temp += 60;
                for (int i = 0; i < temp; i++)
                    _clock.AddSecond();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals {
    public interface IClock {
        Time Time { get; }
        void AddHour();
        void AddMinute();
        void AddSecond();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals {
    public interface IFigure {
        int Len { get; set; }
        int Color { get; set; }
        string Draw();
    }
}
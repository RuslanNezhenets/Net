using System;

namespace Modals {
    public interface IFigure: ICloneable {
        int Len { get; set; }
        int Color { get; set; }
        string Draw();
    }
}
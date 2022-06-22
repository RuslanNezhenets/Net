using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modals.Figures;

namespace Modals {
    public class Editor {
        public IFigure figure;
        public void SetSquares() {
            figure = new Square();
        }
        public void SetTriangle() {
            figure = new Triangle();
        }
        public void NextColor() {
            figure.Color++;
            if (figure.Color == 16)
                figure.Color = 0;
        }
        public void PreviousColor() {
            figure.Color--;
            if (figure.Color == -1)
                figure.Color = 15;
        }
        public void IncreaseLen() {
            figure.Len += 1;
        }
        public void DecreaseLen() {
            figure.Len -= 1;
        }
    }
}

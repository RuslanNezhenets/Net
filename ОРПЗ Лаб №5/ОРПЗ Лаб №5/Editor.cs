using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modals.Figures;

namespace Modals {
    public class Editor {
        public IFigure Figure { get; set; }
        public void SetSquares() {
            Figure = new Square();
        }
        public void SetTriangle() {
            Figure = new Triangle();
        }
        public void NextColor() {
            Figure.Color++;
            if (Figure.Color == 16)
                Figure.Color = 0;
        }
        public void PreviousColor() {
            Figure.Color--;
            if (Figure.Color == -1)
                Figure.Color = 15;
        }
        public void IncreaseLen() {
            Figure.Len++;
        }
        public void DecreaseLen() {
            if(Figure.Len > 0)
                Figure.Len--;
        }
    }
}

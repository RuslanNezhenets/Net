using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Modals.Figures {
    public class Square: IFigure{
        public int Len { get; set; } = 5;
        public int Color { get; set; } = 1;
        public string Draw() {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < Len; i++) {
                for (int j = 0; j < Len; j++) {
                    output.Append("*");
                    if (j < Len - 1)
                        output.Append(" ");
                }
                output.Append(Environment.NewLine);
            }

            return output.ToString();
        }
        public object Clone() {
            return new Square{ Len = Len, Color = Color };
        }
    }
}

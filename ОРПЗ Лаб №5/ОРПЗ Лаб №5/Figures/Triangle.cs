using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Figures {
    public class Triangle: IFigure {
        public int Len { get; set; } = 5;
        public int Color { get; set; } = 1;
        public string Draw() {
            StringBuilder output = new StringBuilder();
            int indent = Len - 1;
            int vertex = 1;

            for (int i = 0; i < Len; i++) {
                for (int j = 0; j < 52; j++) {
                    output.Append(" ");
                    if (j == indent) {
                        for (int k = 0; k < vertex; k++)
                            output.Append("*");
                    }
                }
                indent -= 1;
                vertex += 2;
                output.Append(Environment.NewLine);
            }

            return output.ToString();
        }
        public object Clone() {
            return new Triangle { Len = Len, Color = Color };
        }
    }
}

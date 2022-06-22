using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Commands {
    class CreateSquare: Command {
        public CreateSquare(Application app, Editor editor) : base(app, editor) { }
        public override bool Execute() {
            SaveBackup();
            editor.SetSquares();
            return true;
        }
    }
}

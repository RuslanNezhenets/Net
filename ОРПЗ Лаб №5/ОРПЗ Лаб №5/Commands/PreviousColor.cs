using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Commands {
    class PreviousColor : Command {
        public PreviousColor(Application app, Editor editor) : base(app, editor) { }
        public override bool Execute() {
            SaveBackup();
            editor.PreviousColor();
            return true;
        }
    }
}

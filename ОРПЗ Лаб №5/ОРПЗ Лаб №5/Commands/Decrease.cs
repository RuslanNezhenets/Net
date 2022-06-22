using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Commands {
    class Decrease: Command {
        public Decrease(Application app, Editor editor) : base(app, editor) { }
        public override bool Execute() {
            SaveBackup();
            editor.DecreaseLen();
            return true;
        }
    }
}

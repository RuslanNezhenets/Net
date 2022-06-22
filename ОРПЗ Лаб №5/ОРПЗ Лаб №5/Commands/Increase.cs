using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Commands {
    public class Increase: Command {
        public Increase(Application app, Editor editor): base(app, editor) { }
        public override bool Execute() {
            SaveBackup();
            editor.IncreaseLen();
            return true;
        }
    }
}

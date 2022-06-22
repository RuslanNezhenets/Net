using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Modals.Commands {
    public class NextColor: Command {
        public NextColor(Application app, Editor editor) : base(app, editor) { }
        public override bool Execute() {
            SaveBackup();
            editor.NextColor();
            return true;
        }
    }
}

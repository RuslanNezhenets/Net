using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals.Commands {
    class CreateTriangle:Command {
        public CreateTriangle(Application app, Editor editor) : base(app, editor) { }
        public override bool Execute() {
            SaveBackup();
            editor.SetTriangle();
            return true;
        }
    }
}

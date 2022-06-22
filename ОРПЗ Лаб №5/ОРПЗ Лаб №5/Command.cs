using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals {
    public abstract class Command {
        protected Application app;
        protected Editor editor;
        protected IFigure backup;
        public Command(Application app, Editor editor) {
            this.app = app;
            this.editor = editor;
        }
        public void SaveBackup() {
            backup = editor.figure;
        }
        public void Undo() {
            editor.figure = backup;
        }
        public abstract bool Execute();
    }
}

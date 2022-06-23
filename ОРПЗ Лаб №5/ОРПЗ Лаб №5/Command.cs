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
            backup = (IFigure)editor.Figure?.Clone();
        }
        public void Undo() {
            if(backup != null)
                editor.Figure = (IFigure)backup.Clone();
        }
        public abstract bool Execute();
    }
}

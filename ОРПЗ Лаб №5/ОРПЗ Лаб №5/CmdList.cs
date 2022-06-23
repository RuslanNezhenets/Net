using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modals;

namespace Lab5 {
    enum CmdName {
        SetNextColor = 1,
        SetPreviousColor,
        IncreaseLen,
        DecreaseLen,
        SetSquare,
        SetTriangle,
        Undo
    }
    class CmdList {
        private Application _app;
        private Dictionary<CmdName, Action> _cmd;
        public CmdList(Application app) {
            _app = app;
            _cmd = new Dictionary<CmdName, Action>() {
                { CmdName.SetNextColor, new Action(_app.SetNextColor)},
                { CmdName.SetPreviousColor, new Action(_app.SetPreviousColor)},
                { CmdName.IncreaseLen, new Action(_app.IncreaseLen)},
                { CmdName.DecreaseLen, new Action(_app.DecreaseLen)},
                { CmdName.SetSquare, new Action(_app.SetSquare)},
                { CmdName.SetTriangle, new Action(_app.SetTriangle)},
                { CmdName.Undo, new Action(_app.Undo)}
            };
        }
        public Action this[CmdName name] {
            get => _cmd[name];
        }
        public Action this[int name] {
            get => _cmd[(CmdName)name];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modals;

namespace Lab5 {
    enum CmdName
    {
        SetNextColor = 1,
        SetPreviousColor,
        IncreaseLen,
        DecreaseLen,
        SetSquare,
        SetTriangle,
        Undo
    }
    public delegate void Cmd();
    class CmdList {
        private Application _app;
        private Dictionary<CmdName, Cmd> _cmd;
        public CmdList(Application app) {
            _app = app;
            _cmd = new Dictionary<CmdName, Cmd>() {
                { CmdName.SetNextColor, new Cmd(_app.SetNextColor)},
                { CmdName.SetPreviousColor, new Cmd(_app.SetPreviousColor)},
                { CmdName.IncreaseLen, new Cmd(_app.IncreaseLen)},
                { CmdName.DecreaseLen, new Cmd(_app.DecreaseLen)},
                { CmdName.SetSquare, new Cmd(_app.SetSquare)},
                { CmdName.SetTriangle, new Cmd(_app.SetTriangle)},
                { CmdName.Undo, new Cmd(_app.Undo)}
            };
        }
        public Cmd this[CmdName name] {
            get => _cmd[name];
        }
        public Cmd this[int name] {
            get => _cmd[(CmdName)name];
        }
    }
}

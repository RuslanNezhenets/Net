using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modals.Commands;

namespace Modals {
    public class Application {
        public Editor Editor = new Editor();
        public CommandHistory history = new CommandHistory();
        public void ExecuteCommand(Command command) {
            if (command.Execute())
                history.Push(command);
        }
        public void Undo() {
            Command command = history.Pop();
            if (command != null)
                command.Undo();
        }
        public string Draw() {
            return Editor.figure.Draw();
        }
        public void IncreaseLen() {
            ExecuteCommand(new Increase(this, Editor));
        }
        public void DecreaseLen() {
            ExecuteCommand(new Decrease(this, Editor));
        }
        public void SetNextColor() {
            ExecuteCommand(new NextColor(this, Editor));
        }
        public void SetPreviousColor() {
            ExecuteCommand(new PreviousColor(this, Editor));
        }
        public void SetTriangle() {
            ExecuteCommand(new CreateTriangle(this, Editor));
        }
        public void SetSquare() {
            ExecuteCommand(new CreateSquare(this, Editor));
        }
    }
}

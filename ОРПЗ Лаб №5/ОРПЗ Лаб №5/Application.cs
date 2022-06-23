using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modals.Commands;

namespace Modals {
    public class Application {
        public Editor Editor { get; } = new Editor();
        public CommandHistory History { get; } = new CommandHistory();
        public void ExecuteCommand(Command command) {
            if (command.Execute())
                History.Push(command);
        }
        public void Undo() {
            Command command = History.Pop();
            if (command != null)
                command.Undo();
        }
        public string Draw() {
            return Editor.Figure.Draw();
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

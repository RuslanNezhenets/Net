using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals {
    public class CommandHistory {
        private List<Command> commands = new List<Command>();
        public void Push(Command command) {
            commands.Add(command);
        }
        public Command Pop() {
            int index = commands.Count - 1;
            Command command = commands[index];
            commands.RemoveAt(index);
            return command;
        }
    }
}

using System.Collections.Generic;

namespace Modals {
    public class CommandHistory {
        private readonly IList<Command> commands = new List<Command>();
        public void Push(Command command) {
            commands.Add(command);
        }
        public Command Pop() {
            int index = commands.Count - 1;
            if (index < 0)
                return null;
            Command command = commands[index];
            commands.RemoveAt(index);
            return command;
        }
    }
}
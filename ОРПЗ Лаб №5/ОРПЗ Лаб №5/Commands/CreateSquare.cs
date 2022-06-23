namespace Modals.Commands {
    class CreateSquare: Command {
        public CreateSquare(Application app, Editor editor) : base(app, editor) { }
        public override bool Execute() {
            SaveBackup();
            editor.SetSquares();
            return true;
        }
    }
}
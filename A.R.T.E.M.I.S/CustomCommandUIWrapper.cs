using System;
using System.Windows.Forms;

namespace A.R.T.E.M.I.S
{
    internal sealed class CustomCommandUIWrapper
    {
        public CustomCommandUIWrapper(CustomCommand command, Button button, string commandPath)
        {
            this.command = command;
            this.UIbutton = button;
            this.commandPath = commandPath;
        }
        internal CustomCommand command;
        internal Button UIbutton;
        internal string commandPath;

        private bool flaggedForModification = false;
        internal bool FlaggedForModification { get { return flaggedForModification; } }

        private bool flaggedForAddition = false;
        internal bool FlaggedForAddition { get { return flaggedForAddition; } }

        private bool flaggedForDeletion = false;
        internal bool FlaggedForDeletion { get { return flaggedForDeletion; } }

        internal void FlagForModification() => flaggedForModification = true;

        internal void FlagForAddition() => flaggedForAddition = true;

        internal void FlagForDeletion() => flaggedForDeletion = true;

        internal void UnflagForModification() => flaggedForModification = false;

        internal void UnflagForAddition() => flaggedForAddition = false;

        internal void UnflagForDeletion() => flaggedForDeletion = false;

    }
}

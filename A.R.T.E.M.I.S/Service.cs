using System;
using System.Collections.Generic;

namespace A.R.T.E.M.I.S
{
    internal abstract class Service
    {
        internal string ServiceTag { get; }
        protected List<Command> _afiliateCommands = new List<Command>();

        internal Command GetCommandByTag(string tag)
        {
            foreach(Command cmd in _afiliateCommands)
            {
                if(cmd.MatchById(tag))
                {
                    return cmd;
                }
            }
            return null;
        }

        internal Command GetCommandByName(string commandName)
        {
            foreach(Command cmd in _afiliateCommands)
            {
                if(cmd.FindMatchByName(commandName))
                {
                    return cmd;
                }
            }
            return null;
        }

        protected virtual void RegisterAfiliateCommands() { }
    }
}
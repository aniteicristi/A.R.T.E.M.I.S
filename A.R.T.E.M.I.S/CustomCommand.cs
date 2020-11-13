using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.R.T.E.M.I.S
{
    internal class CustomCommand
    {
        public CustomCommand(string id, string name,string description, List<string> instructionLines)
        {
            this.id = id;
            this.name = name;
            this.instructionLines = instructionLines;
            this.description = description;
        }

        internal string id;
        internal string name;
        internal string description;
        internal List<string> instructionLines;
    }
}

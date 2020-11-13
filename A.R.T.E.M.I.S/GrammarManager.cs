using System.Collections.Generic;
using System.IO;

namespace A.R.T.E.M.I.S
{
    internal static class GrammarManager // One day i might wanna generate all grammars programmaticaly by default. In that case, this class is going to need some serious overloads.
    {
        internal static void GenerateGrammar(string grammarPath, List<CustomCommand> commands)
        {
            string grammarContents = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            grammarContents += @"<grammar version=""1.0"" xml:lang=""en-US"" mode=""voice"" tag-format=""semantics-ms/1.0"" root=""rootRule"" xmlns=""http://www.w3.org/2001/06/grammar"">";
            grammarContents += @"  <rule id=""rootRule"">";
            grammarContents += @"    <one-of>";
            grammarContents += "      <item>ghost  custom command<tag>$=\"0000000\";</tag></item>";
            foreach (CustomCommand cmd in commands)
            {
                    grammarContents += "      <item>" + cmd.name + "<tag>$=\"" + cmd.id + "\";</tag></item>";
            }
            grammarContents += @"    </one-of>";
            grammarContents += @"  </rule>";
            grammarContents += @"</grammar>";

            File.WriteAllText(grammarPath, grammarContents);
        }
    }
}
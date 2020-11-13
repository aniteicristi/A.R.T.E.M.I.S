using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Speech.Recognition;

namespace A.R.T.E.M.I.S
{
    internal sealed class CustomCommandService : Service
    {
        string _grammarPath;
        string _commandsDirectoryPath;
        private string[] _commandsPath;
        private List<CustomCommand> _customCommands;


        public CustomCommandService(AssistantBot assistant)
        {
            _grammarPath = Path.Combine(Directory.GetCurrentDirectory(), "Grammars\\CustomCommandsServices.grxml");
            _commandsDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomCommands");
            _commandsPath = Directory.GetFiles(_commandsDirectoryPath);
            _customCommands = new List<CustomCommand>();
            ReadCommands(assistant);
            RegisterAfiliateCommands();
        }
        protected override void RegisterAfiliateCommands()
        {
            foreach(CustomCommand cmd in _customCommands)
            {
                _afiliateCommands.Add(new Command(
                    cmd.id,
                    cmd.name,
                    null,
                    cmd.description,
                    PraseCommand));
            }
        }

        private void PraseCommand(AssistantBot assistant, Command command, RecognitionResult result)
        {
            foreach(CustomCommand cmd in _customCommands)
            {
                if(command.MatchById(cmd.id))
                {
                    foreach(string line in cmd.instructionLines)
                    {
                        if(line.StartsWith("-s"))
                        {
                            assistant.Speak(line.Substring(3, line.Length - 4));
                        }
                        if(line.StartsWith("-o"))
                        {
                            try
                            {
                                System.Diagnostics.Process.Start(line.Substring(3, line.Length - 4));
                            }
                            catch(Exception ex)
                            {
                                assistant.Speak("I couldn't find what you wannted to open. Be sure you provided a link, or a valid path in the custom command " + cmd.name);
                            }
                        }
                        if(line.StartsWith("-w"))
                        {
                            Thread.Sleep(Convert.ToInt32(line.Substring(3, line.Length - 4)));
                        }
                    }
                    return;
                }
            }
        }

        private void ReadCommands(AssistantBot assistant)
        {
            string cmdId;
            string cmdName;
            string cmdDescription;
            List<string> cmdLines;
            for (int i = 0; i <= _commandsPath.Length - 1; ++i)
            {
                if (!_commandsPath[i].EndsWith(".arts")) continue;
                cmdLines = new List<string>();
                string[] commandLineContents = File.ReadAllLines(_commandsPath[i]);
                cmdId = cmdId = "0" + (300001 + i).ToString();
                cmdName = commandLineContents[1];
                cmdDescription = commandLineContents[2];
                for (int j = 3; j < commandLineContents.Length; ++j)
                    cmdLines.Add(commandLineContents[j]);

                _customCommands.Add(new CustomCommand(cmdId, cmdName, cmdDescription, cmdLines));
            }
            GrammarManager.GenerateGrammar(_grammarPath, _customCommands);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Speech.Recognition;

namespace A.R.T.E.M.I.S
{
    internal sealed class CommandManager
    {
        private AssistantBot _assistant;
        private List<Service> _services;
        private bool _isParsing = false;
        internal bool IsParsing() { return _isParsing; }

        public CommandManager(AssistantBot parent)
        {
            _assistant = parent;
            InitializeServices();
        }

        internal void Prase(RecognitionResult result)
        {
            Command cmd;
            _isParsing = true;
            foreach (Service srv in _services)
            {
                 cmd = srv.GetCommandByTag(result.Semantics.Value.ToString());
                if(cmd != null)
                {
                    cmd.Execute(_assistant, result);
                    _isParsing = false;
                    _assistant.formControl.MinimizeWindow();
                    return;
                }
            }
            _isParsing = false;
            _assistant.Speak("Sorry, I did not understand.");
            _assistant.formControl.MinimizeWindow();
        }

        private void InitializeServices()
        {
            _services = new List<Service>();
            _services.Add(new TimeAndAgendaService(_assistant));
            _services.Add(new SmallTalkService(_assistant));
            _services.Add(new CustomCommandService(_assistant));
            _services.Add(new GitService(_assistant));
            _services.Add(new CodeSupportService(_assistant));
        }

        internal bool CheckCommand(string commandName)
        {
            Command cmd = null;
            foreach(Service serv in _services)
            {
                cmd = serv.GetCommandByName(commandName);
                if (cmd != null)
                    return true;
            }
            return false;
        }
    }
}
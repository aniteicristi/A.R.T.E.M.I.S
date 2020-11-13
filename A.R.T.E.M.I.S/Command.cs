using System;
using System.Speech.Recognition;

namespace A.R.T.E.M.I.S
{
    internal class Command
    {
        private string _id;
        private string _name;
        private string[] _alternatives;
        private Action<AssistantBot, Command, RecognitionResult> _commandAction;

        public string Description { get; }

        public Command(string id, string name, string[] alternatives,string description, Action<AssistantBot, Command, RecognitionResult> action)
        {
            _id = id;
            _name = name;
            _alternatives = alternatives;
            Description = description;
            _commandAction = action;
        }

        public void Execute(AssistantBot assistant, RecognitionResult result) => _commandAction(assistant, this, result);

        public bool FindMatchByName(string searchedCommand)
        {
            if (searchedCommand == _name)
                return true;
            if(_alternatives != null)
            {
                for (int i = 0; i < _alternatives.Length; ++i)
                {
                    if (searchedCommand == _alternatives[i])
                        return true;
                }
            }
            return false;
        }
        public bool MatchById(string id)
        {
            return id == _id;
        }

    }
}
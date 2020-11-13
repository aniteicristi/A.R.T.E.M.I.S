using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;

namespace A.R.T.E.M.I.S
{
    public sealed class AssistantBot
    {
        internal MainForm formControl;

        private AssistantInformation information;
        internal AssistantInformation Information
        {
            get
            {
                return information;
            }
        }

        private SpeechSynthesizer _speaker;

        private SpeechListener _speechListener;

        private CommandManager _commandManager;

        private NotificationManager _notificationManager;

        public AssistantBot(MainForm form)
        {
            formControl = form;
            _speaker = new SpeechSynthesizer();
            _speaker.SetOutputToDefaultAudioDevice();
            _speaker.SelectVoiceByHints(VoiceGender.Female);
            information = new AssistantInformation();
            _commandManager = new CommandManager(this);
            _speechListener = new SpeechListener(this);
            _notificationManager = new NotificationManager(this);
        }

        internal void OnRecognition(object sender, SpeechRecognizedEventArgs e)
        {
            _commandManager.Prase(e.Result);
        }

        internal void Listen() => _speechListener.Listen();

        internal void Speak(string text)
        {
            _speaker.Speak(text);
            Thread.Sleep(150);
        }

        internal bool IsListening()
        {
            return _speechListener.IsListening;
        }
        internal bool IsParsing()
        {
            return _commandManager.IsParsing();
        }
        internal bool CheckCommand(string command) => _commandManager.CheckCommand(command);
    }
}
using System;
using System.IO;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace A.R.T.E.M.I.S
{
    internal sealed class SpeechListener
    {
        private string _grammarsPath;
        private SpeechRecognitionEngine _speechRecognizer;
        private AssistantBot _assistant;
        private System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.Combine(Directory.GetCurrentDirectory(), "wakeUpSound.wav"));
        private bool _isListening = false;
        public bool IsListening
        {
            get { return _isListening; }
        }

        public SpeechListener(AssistantBot parent)
        {
            try
            {
                _assistant = parent;
                _speechRecognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
                _speechRecognizer.SetInputToDefaultAudioDevice(); 
                _speechRecognizer.SpeechRecognized += SpeechRecognized;
                _speechRecognizer.SpeechRecognized += _assistant.OnRecognition;
                _speechRecognizer.SpeechHypothesized += (o,e) => { _assistant.formControl.UpdateSpeechHypothesis(e.Result.Text); };
                _grammarsPath = Path.Combine(Directory.GetCurrentDirectory(), "Grammars");
                string[] grammars = Directory.GetFiles(_grammarsPath);
                for(int i = 0; i < grammars.Length; ++i)
                {
                    _speechRecognizer.LoadGrammar(new Grammar(grammars[i]));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Grammars", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            _isListening = false;
            _speechRecognizer.RecognizeAsyncStop();
        }

        internal void Listen()
        {
            _isListening = true;
            player.Play();
            _speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        
    }
}
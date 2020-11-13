using System.Speech.Recognition;
using System;
using System.Drawing;
using System.Windows.Forms;
/*
 *  TODO:
 * 
 */
namespace A.R.T.E.M.I.S
{
    public partial class MainForm : Form
    {
        private AssistantBot _Artemis;
        private SpeechRecognitionEngine _keyWordRecognizer;
        private bool _muted = false;

        public MainForm()
        {
            InitializeComponent();
            _Artemis = new AssistantBot(this);
            this.FormBorderStyle = FormBorderStyle.None;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Top);
            InitializeKeyWordRecognizer();
            this.FormClosed += (sender,e) => notifyIcon.Visible = false;

        }

        private void MainForm_Load(object sender, EventArgs e) => MinimizeWindow();

        private void MutedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _muted = !_muted;
            MinimizeWindow();
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                MaximizeWindow();
            }
            else if (WindowState == FormWindowState.Normal)
            {
                MinimizeWindow();
            }
        }

        private void InitializeKeyWordRecognizer()
        {
            try
            {
                _keyWordRecognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
                _keyWordRecognizer.SetInputToDefaultAudioDevice();
                _keyWordRecognizer.SpeechRecognized += OnWakeUp;
                _keyWordRecognizer.LoadGrammar(new Grammar(new GrammarBuilder(new Choices("hey artemis"))));
                _keyWordRecognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
        }

        private void OnWakeUp(object sender, SpeechRecognizedEventArgs e)
        {
            if(!_Artemis.IsListening() && !_muted && !_Artemis.IsParsing())
            {
                BringToFront();
                MaximizeWindow();
                _Artemis.Listen();
            }
        }
        
        internal void MaximizeWindow()
        {
            BringToFront();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Show();
        }

        internal void MinimizeWindow()
        {
            speechHypothesisTextBox.Clear();
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Hide();
        }

        internal void UpdateSpeechHypothesis(string text) => speechHypothesisTextBox.Text = text;

        internal void Restart() => Application.Restart();

        internal void MuteAssistant() => mutedCheckBox.Checked = true;
    }
}
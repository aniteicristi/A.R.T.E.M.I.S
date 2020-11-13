using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace A.R.T.E.M.I.S
{
    class CodeSupportService : Service
    {
        private AssistantBot _assistant;
        private string _grammarPath;
        private string _presetsDirectoryPath;
        private string[] _presetsPath;
        private string[] _presetsHandle;

        public CodeSupportService(AssistantBot assistant)
        {
            _presetsDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Presets");
            _grammarPath = Path.Combine(Directory.GetCurrentDirectory(), "Grammars\\CodeSupportServices.xml");
            _presetsPath = Directory.GetFiles(_presetsDirectoryPath);
            _presetsHandle = new string[_presetsPath.Length];
            LoadPresets();
            RegisterAfiliateCommands();
            _assistant = assistant;
            
        }

        private void LoadPresets()
        {
            for(int i = 0; i < _presetsPath.Length; ++i)
            {
                if (!_presetsPath[i].EndsWith(".txt")) continue;

                string[] folders = _presetsPath[i].Split('\\');
                _presetsHandle[i] = folders.Last().Substring(0, folders.Last().Length - 4);
            }
            GenerateGrammar();
        }

        protected override void RegisterAfiliateCommands()
        {
            _afiliateCommands.Add(new Command(
                "0500001",
                "load <presets>",
                new string[] { "copy <presets>" },
                "Loads selected preset to the clipboard.",
                (assistant, cmd, result) =>
                {
                    for(int i = 0; i < _presetsHandle.Length; ++i)
                    {
                        if(result.Text.Contains(_presetsHandle[i]))
                        {
                            if(!File.Exists(_presetsPath[i]))
                            {
                                assistant.Speak("Sorry. The preset you're trying to load does not exist.");
                                return;
                            }
                            else
                            {
                                string contents = File.ReadAllText(_presetsPath[i]);
                                Clipboard.SetText(contents);
                                assistant.Speak(_presetsHandle[i] + " preset has been copied to your clipboard.");
                                return;
                            }
                        }
                    }
                    assistant.Speak("Sorry. I could not find that preset. Be sure you have it saved.");
                }));

            _afiliateCommands.Add(new Command(
                "0500002",
                "read my clipboard out lout",
                new string[] { "what's in my clipboard", "read my clipboard", "read clipboard"},
                "Reads you the contents of your clipboard.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak(Clipboard.GetText());
                }));

            _afiliateCommands.Add(new Command(
                "0500003",
                "save my clipboard",
                new string[] { "save clipboard" },
                "Takes the string form your clipboard and creates a new preset.",
                (assistant, cmd, result) =>
                {
                    string contents = Clipboard.GetText();
                    string path;
                    OpenFileDialog selectFile = new OpenFileDialog();
                    selectFile.Title = "Select a file.";
                    selectFile.InitialDirectory = Environment.CurrentDirectory;
                    if (selectFile.ShowDialog() == DialogResult.OK)
                    {
                        path = Path.GetFullPath(selectFile.FileName);
                        if (!path.EndsWith(".txt"))
                        {
                            assistant.Speak("Sorry, i can only save under text files.");
                        }
                        MessageBox.Show("Warning. The name you save under will also be the handle with which you call the preset.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        File.WriteAllText(path, contents);
                        assistant.Speak("Saved " + selectFile.FileName.Split('\\').Last() + " under presets.");

                    }
                }));

            _afiliateCommands.Add(new Command(
                "0500004",
                "wipe my clipboard",
                new string[] { "wipe clipboard" },
                "Makes your clipboard information equal to an space character.",
                (assistant, cmd, result) =>
                {
                    Clipboard.SetText(" ");
                    assistant.Speak("Clipboard wiped.");
                }));

            _afiliateCommands.Add(new Command(
                "0500005",
                "search my clipboard",
                new string[] { "search clipboard", "google clipboard" },
                "Performs a google search on the contents of your clipboard.",
                (assistant, cmd, result) =>
                {
                    string searchPrefix = "https://www.google.ro/search?authuser=0&source=hp&ei=mfcUW7TeIsPXkwWctJz4CA&q=";
                    string searchKeyWords = Clipboard.GetText();
                    
                    Process.Start(searchPrefix + searchKeyWords.Replace(' ', '+'));
                }));

            _afiliateCommands.Add(new Command(
                "0500006",
                "show me my presets",
                new string[] { "show my presets", "open presets folder", "show me presets folder","show me the presets folder" },
                "Opens the presets folder.",
                (assitant, cmd, result) =>
                {
                    Process.Start(_presetsDirectoryPath);
                }));

            _afiliateCommands.Add(new Command(
                "0500007",
                "delete <presets>",
                new string[] { "remove <presets>" },
                "Delete a certain preset.",
                (assistant, cmd, result) =>
                {
                    for (int i = 0; i < _presetsHandle.Length; ++i)
                    {
                        if (result.Text.Contains(_presetsHandle[i]))
                        {
                            if (!File.Exists(_presetsPath[i]))
                            {
                                assistant.Speak("Sorry. The preset you're trying to delete does not exist.");
                                return;
                            }
                            else
                            {
                                File.Delete(_presetsPath[i]);
                                assistant.Speak(_presetsHandle[i] + " preset has been deleted.");
                                return;
                            }
                        }
                    }
                }));
        }

        private void GenerateGrammar()
        {
            string[] grammarContents = File.ReadAllLines(_grammarPath);
            int i;
            for (i = 0; i < grammarContents.Length; ++i)
            {
                if(grammarContents[i].StartsWith("  <rule id=\"presets\">"))
                {
                    grammarContents[i] = "  <rule id=\"presets\">";
                    grammarContents[i] += "  <one-of>";
                    foreach(string str in _presetsHandle)
                    {
                        grammarContents[i] += "    <item>" + str + "</item>";
                    }
                    grammarContents[i] += "<item>ghost</item>";
                    grammarContents[i] += "  </one-of>";
                    grammarContents[i] += @"  <item repeat=""0-1""> preset</item>";
                     grammarContents[i] += "</rule>";
                }
            }
            File.WriteAllLines(_grammarPath, grammarContents);
        }
    }
}

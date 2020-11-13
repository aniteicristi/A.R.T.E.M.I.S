using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LibGit2Sharp;

namespace A.R.T.E.M.I.S
{
    public partial class GitConfigurationPanel : Form
    {
        private AssistantBot _assistant;
        private string _repositoryPath;
        private string _repositoriesFile;



        public GitConfigurationPanel(AssistantBot assistant)
        {
            InitializeComponent();
            _repositoryPath = null;
            _assistant = assistant;
            _repositoriesFile = Path.Combine(Environment.CurrentDirectory, "Repositories.txt");
        }

        private void LocalPathButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult = fbd.ShowDialog();
                if(DialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    gitLocalLable.Text += " " + fbd.SelectedPath;
                    _repositoryPath = fbd.SelectedPath;
                }
            }
        }

        private void CloneButton_Click(object sender, EventArgs e)
        {
            if (_repositoryPath == null)
            {
                _assistant.Speak("Please provide me with a path to the repository directory.");
                return;
            }

            if(gitName.Text == "")
            {
                _assistant.Speak("Sorry. You have to give me a name for your repository.");
                return;
            }
            if (gitPath.Text.StartsWith(@"https://bitbucket.org") && gitPath.Text != "")
            {
                try
                {
                    Repository.Clone(gitPath.Text, _repositoryPath);
                    string[] repositories = File.ReadAllLines(_repositoriesFile);
                    List<string> repos = repositories.ToList();
                    repos.Add(gitName.Text + "|" + Path.Combine(_repositoryPath, ".git"));
                    File.WriteAllLines(_repositoriesFile, repos);
                    _assistant.Speak("Repository cloned!");
                }
                catch(Exception ex)
                {
                    _assistant.Speak("Error ocoured:" + ex.Message);
                }
            }
            else
            {
                if(!_repositoryPath.EndsWith(".git"))
                {
                    _assistant.Speak("Pleas specifiy a path to a git repository.");
                    return;
                }
                string[] repositories = File.ReadAllLines(_repositoriesFile);
                List<string> repos = repositories.ToList();
                repos.Add(gitName.Text + "|" + _repositoryPath);
                File.WriteAllLines(_repositoriesFile, repos);
                _assistant.Speak("Repository registered!");
            }

            
        }

        private void GitConfigurationPanel_Load(object sender, EventArgs e)
        {
            savedRepoList.Text = File.ReadAllText(_repositoriesFile);
        }

    }
}

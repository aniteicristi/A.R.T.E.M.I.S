using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace A.R.T.E.M.I.S
{
    public sealed partial class CustomCommandPanel : Form
    {
        private string _commandsDirectoryPath;
        private List<CustomCommandUIWrapper> _customCommands;
        private CustomCommandUIWrapper _selectedCommand;
        private CustomCommandUIWrapper _emptyCommand;
        private AssistantBot _assistant;

        public CustomCommandPanel(AssistantBot assistant)
        {
            InitializeComponent();
            _customCommands = new List<CustomCommandUIWrapper>();
            _assistant = assistant;
        }

        private void CustomCommandPanel_Load(object sender, EventArgs e)
        {
            _commandsDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomCommands");
            _emptyCommand = new CustomCommandUIWrapper(new CustomCommand("", "", "", new List<string>()), new Button(), "");
            LoadCommands();
            if (_customCommands.Count > 0)
                _selectedCommand = _customCommands.First();
            else
                _selectedCommand = _emptyCommand;
            UpdateSelectedCommand();
            FormClosed += SaveCommandButton_Click;
        }

        private void SelectButton(object sender, EventArgs e) /// this gets confused when you have 2 commands of the same name.
        {
            string clickedCommandName = ((Button)sender).Text;
            QuickSave();
            foreach(CustomCommandUIWrapper cmd in _customCommands)
            {
                if (cmd.command.name == clickedCommandName && !cmd.FlaggedForDeletion)
                {
                    _selectedCommand = cmd;
                }
            }
            UpdateSelectedCommand();
        }

        private void LoadCommands()
        {
            string[] paths = Directory.GetFiles(_commandsDirectoryPath);
            string cmdId;
            string cmdName;
            string cmdDescription;
            CustomCommandUIWrapper cmd;
            List<string> cmdLines;
            for (int i = 0; i < paths.Length; ++i)
            {
                if (!paths[i].EndsWith(".arts")) continue;
                cmdLines = new List<string>();
                string[] commandLineContents = File.ReadAllLines(paths[i]);
                cmdId = "0" + (300001 + i).ToString();
                cmdName = commandLineContents[1];
                cmdDescription = commandLineContents[2];
                for (int j = 3; j < commandLineContents.Length; ++j)
                    cmdLines.Add(commandLineContents[j]);

                Button UIButton = new Button();
                UIButton.Size = new Size(150, 50);
                UIButton.Text = cmdName;
                UIButton.Click += SelectButton;
                commandsPanel.Controls.Add(UIButton);
                cmd = new CustomCommandUIWrapper(new CustomCommand(cmdId, cmdName, cmdDescription, cmdLines), UIButton, paths[i]);
                _customCommands.Add(cmd);
            }
        }

        private void QuickSave()
        {
            if (_selectedCommand == _emptyCommand)
                return;

            _selectedCommand.command.instructionLines.Clear();
            for (int i = 0; i < commandCodeLines.Lines.Length; ++i)
            {
                _selectedCommand.command.instructionLines.Add(commandCodeLines.Lines[i]);
            }
            _selectedCommand.command.description = commandDescription.Text;
            _selectedCommand.FlagForModification();
        }

        private void Save()
        {
            foreach (CustomCommandUIWrapper cmd in _customCommands)
            {
                if(cmd.FlaggedForAddition && !cmd.FlaggedForDeletion && _assistant.CheckCommand(cmd.command.name))
                {
                    MessageBox.Show("The command: " + cmd.command.name + " already exists! Please change the name so it will not conflict with other existing commands.", "Invalid Command Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 

                if (cmd.FlaggedForDeletion && !cmd.FlaggedForAddition)
                {
                    File.Delete(cmd.commandPath);
                    continue;
                }

                if (cmd.FlaggedForAddition && !cmd.FlaggedForDeletion)
                {
                    if(cmd.command.name != "" && cmd.command.instructionLines.Count != 0)
                    {
                        cmd.commandPath = Path.Combine(_commandsDirectoryPath, cmd.command.name + ".arts");
                        cmd.FlagForModification();
                        cmd.UnflagForAddition();
                    }  
                }

                if (cmd.commandPath != "" && cmd.FlaggedForModification && !cmd.FlaggedForDeletion)
                {
                    string[] commandFileContents = new string[3 + cmd.command.instructionLines.Count];
                    commandFileContents[0] = cmd.command.id;
                    commandFileContents[1] = cmd.command.name;
                    commandFileContents[2] = cmd.command.description;
                    int i = 3;
                    foreach(string line in cmd.command.instructionLines)
                    {
                        commandFileContents[i] = line;
                        i++;
                    }
                    File.WriteAllLines(cmd.commandPath, commandFileContents);
                    cmd.UnflagForModification();
                }
            }
        }

        private void UpdateSelectedCommand()
        {
            if (_selectedCommand == null)
                _selectedCommand = _emptyCommand;

            commandName.Text = _selectedCommand.command.name;
            commandDescription.Text = _selectedCommand.command.description;
            commandCodeLines.Clear();
            if(_selectedCommand.command.instructionLines.Count > 0)
                commandCodeLines.AppendText(_selectedCommand.command.instructionLines.First());

            for (int i = 1; i < _selectedCommand.command.instructionLines.Count; ++i)
                commandCodeLines.AppendText(Environment.NewLine + _selectedCommand.command.instructionLines[i]);
            
        }

        private void InsertLinkButton_Click(object sender, EventArgs e)
        {
            commandCodeLines.AppendText(Environment.NewLine + "-o https:// ;");
            _selectedCommand.FlagForModification();
        }

        private void InsertWaitButton_Click(object sender, EventArgs e)
        {
            commandCodeLines.AppendText(Environment.NewLine + "-w ;");
            _selectedCommand.FlagForModification();
        }

        private void InsertDialogueButton_Click(object sender, EventArgs e)
        {
            commandCodeLines.AppendText(Environment.NewLine + "-s ;");
            _selectedCommand.FlagForModification();
        }

        private void InsertPathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFile = new OpenFileDialog();
            selectFile.Title = "Select a File";
            selectFile.InitialDirectory = @"C:\";
            if(selectFile.ShowDialog() == DialogResult.OK)
            {
                commandCodeLines.AppendText(Environment.NewLine + "-o " + Path.GetFullPath(selectFile.FileName) + ";");
            }
            _selectedCommand.FlagForModification();
        }

        private void CommandName_TextChanged(object sender, EventArgs e)
        {
            _selectedCommand.FlagForModification();
            _selectedCommand.command.name = commandName.Text;
            _selectedCommand.UIbutton.Text = commandName.Text;
        }

        private void NewCommandButton_Click(object sender, EventArgs e)
        {
            Button UIButton = new Button();
            UIButton.Size = new Size(150, 50);
            UIButton.Text = "New Command";
            UIButton.Click += SelectButton;
            commandsPanel.Controls.Add(UIButton);
            CustomCommandUIWrapper cmd = new CustomCommandUIWrapper(new CustomCommand("0" + (300001 + _customCommands.Count), "New Command", "", new List<string>()), UIButton, "");
            _customCommands.Add(cmd);
            _selectedCommand = cmd;
            cmd.FlagForAddition();
            UpdateSelectedCommand();
        }

        private void SaveCommandButton_Click(object sender, EventArgs e)
        {
            QuickSave();
            Save();
        }

        private void DeleteCommandButton_Click(object sender, EventArgs e)
        {
            commandsPanel.Controls.Remove(_selectedCommand.UIbutton);
            _selectedCommand.command.name = "----";
            _selectedCommand.FlagForDeletion();
            _selectedCommand = _customCommands.First();
            UpdateSelectedCommand();
        }


    }
}

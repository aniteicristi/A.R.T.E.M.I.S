using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace A.R.T.E.M.I.S
{
    internal sealed class GitService : Service
    {
        Dictionary<string, Repository> _repositories;
        string _repositoriesFilePath;
        string _grammarPath;

        public GitService(AssistantBot assistant)
        {
            _repositories = new Dictionary<string, Repository>();
            _repositoriesFilePath = Path.Combine(Environment.CurrentDirectory, "Repositories.txt");
            _grammarPath = Path.Combine(Environment.CurrentDirectory, @"Grammars\GitServices.xml");
            RegisterAfiliateCommands();
            RegisterRepositories();
            GenerateGrammar(); 
        }

        private void GenerateGrammar()
        {
            string[] grammarContents = File.ReadAllLines(_grammarPath);
            int i;
            for (i = 0; i < grammarContents.Length; ++i)
            {
                if (grammarContents[i].StartsWith("  <rule id=\"repos\">"))
                {
                    grammarContents[i] = "  <rule id=\"repos\">";
                    grammarContents[i] += "  <one-of>";
                    foreach (string key in _repositories.Keys)
                    {
                        grammarContents[i] += "    <item>" + key + "</item>";
                    }
                    grammarContents[i] += "<item>ghost</item>";
                    grammarContents[i] += "  </one-of>";
                    grammarContents[i] += @"  <item repeat=""0-1""> repository</item>";
                    grammarContents[i] += "</rule>";
                }
            }
            File.WriteAllLines(_grammarPath, grammarContents);
        }

        private void RegisterRepositories()
        {
            string[] repos = File.ReadAllLines(_repositoriesFilePath);
            foreach(string repo in repos)
            {
                string[] details = repo.Split('|');
                try
                {
                    _repositories.Add(details[0], new Repository(details[1]));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        protected override void RegisterAfiliateCommands()
        {
            _afiliateCommands.Add(new Command(
                "0400001",
                "open source tree",
                new string[] { "run source tree" },
                "Opens sourceTree.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening source tree.");
                    try
                    {
                        System.Diagnostics.Process.Start(@"C:\Users\Christian Nitas\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Atlassian\SourceTree.lnk");
                    }
                    catch (Exception ex)
                    {
                        assistant.Speak("It appears that you might not have Source Tree installed.");
                    }
                }));

            _afiliateCommands.Add(new Command(
                "0400002",
                "open git panel",
                new string[] { "open git configuration panel", "show git panel", "show git configuration panel" },
                "Opens the git configuration panel",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening git configuration panel. Hold on.");
                    GitConfigurationPanel gcp = new GitConfigurationPanel(assistant);
                    gcp.Show();
                }));

            _afiliateCommands.Add(new Command(
                "0400003",
                "commit <repository>",
                new string[] { "commit changes to <repository>" },
                "Commits changes to the specified repository.",
                (assistant, cmd, result) =>
                {
                    int argOffset;
                    if (result.Text.StartsWith("commit changes to "))
                        argOffset = "commit changes to ".Length;
                    else
                        argOffset = "commit to ".Length;
                    string argument = result.Text.Substring(argOffset);
                    if (_repositories.ContainsKey(argument))
                    {
                        try
                        {
                            Commands.Stage(_repositories[argument], "*");
                            Signature sign = new Signature(assistant.Information.Owner, assistant.Information.OwnerEmail, DateTime.Now);
                            _repositories[argument].Commit("Commit message", sign, sign);
                            assistant.Speak("Changes commited to " + argument);
                        }
                        catch(Exception ex)
                        {
                            assistant.Speak("Error ocoured: " + ex.Message);
                        }
                    }
                    else
                    {
                        assistant.Speak("The specified repository does not exist in my memory.");
                    }
                }));

            _afiliateCommands.Add(new Command(
                "0400004",
                "push to <repository>",
                new string[] { "push changes to <repository>" },
                "Performs a push to the specified repository.",
                (assistant, cmd, result) =>
                {
                    int argOffset;
                    if (result.Text.StartsWith("push changes to "))
                        argOffset = "push changes to ".Length;
                    else
                        argOffset = "push to ".Length;
                    string argument = result.Text.Substring(argOffset);
                    if(_repositories.ContainsKey(argument))
                    {
                        try
                        {
                            Remote remote = _repositories[argument].Network.Remotes["origin"];
                            var creds = new UsernamePasswordCredentials()
                            {
                                Username = assistant.Information.bitBucketUsername,
                                Password = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "gitpassword.secret"))
                            };
                            CredentialsHandler credHandler = (_url, _user, _cred) => creds;
                            PushOptions options = new PushOptions
                            {
                                CredentialsProvider = credHandler
                            };
                            _repositories[argument].Network.Push(remote, @"refs/heads/master", options);
                            assistant.Speak("Changes pushed to " + argument);
                        }
                        catch(Exception ex)
                        {
                            assistant.Speak("Error ocured: " + ex.Message);
                        }
                    }
                    else
                    {
                        assistant.Speak("The specified repository does not exist in my memory.");
                    }
                }));

            _afiliateCommands.Add(new Command(
                "0400005",
                "commit and push to <repository>",
                new string[] { "commit and push changes to <repository>" },
                "Performs a commit and a push to the specified repository.",
                (assistant, cmd, result) =>
                {
                    int argOffset;
                    if (result.Text.StartsWith("commit and push changes to "))
                        argOffset = "commit and push changes to ".Length;
                    else
                        argOffset = "commit and push to ".Length;
                    string argument = result.Text.Substring(argOffset);
                    if(_repositories.ContainsKey(argument))
                    {
                        try
                        {
                            Commands.Stage(_repositories[argument], "*");
                            Signature sign = new Signature(assistant.Information.Owner, assistant.Information.OwnerEmail, DateTime.Now);
                            _repositories[argument].Commit("Commit message", sign, sign);
                            Remote remote = _repositories[argument].Network.Remotes["origin"];
                            var creds = new UsernamePasswordCredentials()
                            {
                                Username = assistant.Information.bitBucketUsername,
                                Password = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "gitpassword.secret"))
                            };
                            CredentialsHandler credHandler = (_url, _user, _cred) => creds;
                            PushOptions options = new PushOptions
                            {
                                CredentialsProvider = credHandler
                            };
                            _repositories[argument].Network.Push(remote, @"refs/heads/master", options);
                            assistant.Speak("Changes commited and pushed to " + argument);
                        }
                        catch (Exception ex)
                        {
                            assistant.Speak("Error ocured: " + ex.Message);
                        }
                    }
                    else
                    {
                        assistant.Speak("The specified repository does not exist in my memory.");
                    }
                }));

            _afiliateCommands.Add(new Command(
                "0400006",
                "fetch <repository>",
                new string[] { "fetch from <repository>" },
                "Performs a fetch from the specified repository.",
                (assistant, cmd, result) => 
                {
                    int argOffset;
                    if (result.Text.StartsWith("fetch from "))
                        argOffset = "fetch from ".Length;
                    else
                        argOffset = "fetch ".Length;
                    string argument = result.Text.Substring(argOffset);
                    if(_repositories.ContainsKey(argument))
                    {
                        try
                        {
                            string logMessage = "";
                            FetchOptions options = new FetchOptions();
                            options.CredentialsProvider = new CredentialsHandler((url, usernameFromUrl, types) =>
                                new UsernamePasswordCredentials()
                                {
                                    Username = assistant.Information.bitBucketUsername,
                                    Password = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "gitpassword.secret"))
                                });

                            foreach (Remote remote in _repositories[argument].Network.Remotes)
                            {
                                IEnumerable<string> refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                                Commands.Fetch(_repositories[argument], remote.Name, refSpecs, options, logMessage);
                            }
                            assistant.Speak("Successfuly fetched from " + argument);
                        }
                        catch(Exception ex)
                        {
                            assistant.Speak("Error ocoured: " + ex.Message);
                        }
                    }
                    else
                    {
                        assistant.Speak("The specified repository does not exist in my memory.");
                    }
                }));

            _afiliateCommands.Add(new Command(
                "0400007",
                "pull from <repository>",
                new string[] { "pull <repository>" },
                "Performs pull from the specified repository.",
                (assistant, cmd, result) => 
                {
                    int argOffset;
                    if (result.Text.StartsWith("pull from "))
                        argOffset = "pull from ".Length;
                    else
                        argOffset = "pull ".Length;
                    string argument = result.Text.Substring(argOffset);
                    if (_repositories.ContainsKey(argument))
                    {
                        try
                        {
                            PullOptions options = new PullOptions();
                            options.FetchOptions = new FetchOptions();
                            options.FetchOptions.CredentialsProvider = new CredentialsHandler(
                                (url, usernameFromUrl, types) =>
                                    new UsernamePasswordCredentials()
                                    {
                                        Username = assistant.Information.bitBucketUsername,
                                        Password = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "gitpassword.secret"))
                                    });
                            Signature sign = new Signature(assistant.Information.Owner, assistant.Information.OwnerEmail, DateTime.Now);
                            Commands.Pull(_repositories[argument], sign, options);
                            assistant.Speak("Successfuly pulled from " + argument);
                        }
                        catch (Exception ex)
                        {
                            assistant.Speak("Error ocoured: " + ex.Message);
                        }
                    }
                    else
                    {
                        assistant.Speak("The specified repository does not exist in my memory.");
                    }
                }));
        }
    }
}

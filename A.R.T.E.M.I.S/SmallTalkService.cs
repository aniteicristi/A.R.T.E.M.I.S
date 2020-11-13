using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.R.T.E.M.I.S
{
    internal sealed class SmallTalkService : Service
    {
        Random _randomizer;

        public SmallTalkService(AssistantBot assistant)
        {
            _afiliateCommands = new List<Command>();
            _randomizer = new Random();
            RegisterAfiliateCommands();
        }

        protected override void RegisterAfiliateCommands()
        {
            _afiliateCommands.Add(new Command(
                "0200001",
                "how are you",
                new string[] { "how do you do", "what's up", "how is it going" },
                "Makes a small conversation.",
                (assistant, cmd, result) =>
                {
                    string[] possibleResponses = new string[]
                    {
                        "I am well, ready to assist you.",
                        "I am excelent. Tell me if you need anything.",
                        "I'm feeling like i could take over the world. Of course, i couldn't even if i wanted... hehe.",
                        "Awaiting your orders cap!",
                        "Awaiting further instructions.",
                        "Standing by."
                    };
                    assistant.Speak(possibleResponses[_randomizer.Next(0, possibleResponses.Length - 1)]);
                }));

            _afiliateCommands.Add(new Command(
                "0200002",
                "open notepad",
                new string[] { "run notepad", "execute notepad" },
                "Opens windows notepad.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening Notepad.");
                    try
                    {
                        System.Diagnostics.Process.Start(@"C:\Users\Cristi\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Accessories\Notepad.lnk");
                    }
                    catch(Exception ex)
                    {
                        assistant.Speak("I couldn't open Notepad. Please check if it is in the right directory.");
                    }
                    
                }));

            _afiliateCommands.Add(new Command(
                "0200003",
                "open browser",
                new string[] { "run browser", "open google"},
                "Opens the default browser.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening browser.");
                    System.Diagnostics.Process.Start("https://www.google.ro/");
                }));

            _afiliateCommands.Add(new Command(
                "0200005",
                "open visual studio",
                new string[] { "run visual studio" },
                "Opens visual studio.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening visual studio.");
                    try
                    {
                        System.Diagnostics.Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Visual Studio 2017.lnk");
                    }
                    catch(Exception ex)
                    {
                        assistant.Speak("It appears that you might not have visual studio installed.");
                    }
                    
                }));

            _afiliateCommands.Add(new Command(
                "0200006",
                "open photoshop",
                new string[] { "run photoshop" },
                "Opens photoshop.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening photoshop.");
                    try
                    {
                        System.Diagnostics.Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Adobe Photoshop CS6 (64 Bit).lnk");
                    }
                    catch(Exception ex)
                    {
                        assistant.Speak("It appears that you might not have photoshop installed.");
                    }
                    
                }));

            _afiliateCommands.Add(new Command(
                "0200007",
                "open calculator",
                new string[] { "run calculator" },
                "Opens windows calculator.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening calculator.");
                    System.Diagnostics.Process.Start(@"calc.exe");
                }));

            _afiliateCommands.Add(new Command(
                "0200008",
                "open explorer",
                new string[] { "run explorer", "open file explorer","run file explorer" },
                "Opens windows file explorer.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening file explorer.");
                    System.Diagnostics.Process.Start(@"explorer.exe");
                }));

            _afiliateCommands.Add(new Command(
                "0200009",
                "open unity",
                new string[] { "run unity" },
                "Opens unity game engine.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening unity.");
                    try
                    {
                        System.Diagnostics.Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Unity 2018.1.0f2 (64-bit)\Unity.lnk");
                    }
                    catch(Exception ex)
                    {
                        assistant.Speak("It appears that you might not have unity installed.");
                    }
                    
                }));

            _afiliateCommands.Add(new Command(
                "0200010",
                "open paint",
                new string[] { "run paint" },
                "Opens MS paint.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening microsoft paint.");
                    try
                    {
                        System.Diagnostics.Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Accessories\Paint.lnk");
                    }
                    catch (Exception ex)
                    {
                        assistant.Speak("I couldn't find microsoft paint on your computer. Please check the file location.");
                    }
                    
                }));

            _afiliateCommands.Add(new Command(
                "0200011",
                "nevermind",
                new string[] { "nothing" },
                "Dismisses Artemis.",
                (assistant, cmd, result) =>
                {

                }));

            _afiliateCommands.Add(new Command(
                "0200012",
                "flip a coin",
                new string[] { "flip me a coin" },
                "Flips you a coin for heads or tails.",
                (assistant, cmd, result) =>
                {
                    int coin = _randomizer.Next(0, 2);
                    if (coin == 1)
                        assistant.Speak("You flipped tails.");
                    else
                        assistant.Speak("You flipped heads. ");
                }));

            _afiliateCommands.Add(new Command(
                "0200013",
                "open g mail",
                new string[] { "open email" },
                "Opens google email.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening G mail.");
                    System.Diagnostics.Process.Start("https://mail.google.com/mail");
                }));

            _afiliateCommands.Add(new Command(
                "0200014",
                "let's play rock paper scissors",
                new string[] { "play rock paper scissors", "play with me rock paper scissors" },
                "Plays rock paper scissors with you.",
                (assistant, cmd, result) =>
                {
                    string[] s = { "rock", "paper", "scissors" };
                    assistant.Speak("Alright. After three. One. Two. Three. " + s[_randomizer.Next(0,2)]);
                }));

            _afiliateCommands.Add(new Command(
                "0200015",
                "open custom command panel",
                new string[] { "open command panel", "show command panel", "show custom command panel", "display command panel", "display custom command panel" },
                "Displays the Custom Command Panel Form",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening custom commands panel. Hold on.");
                    CustomCommandPanel panel = new CustomCommandPanel(assistant);
                    panel.Show();
                }));

            _afiliateCommands.Add(new Command(
                "0200016",
                "restart your system",
                new string[] { "perform a system restart" },
                "Restarts Artemis.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Restarting in Three. Two. One.");
                    assistant.formControl.Restart();
                }));

            _afiliateCommands.Add(new Command(
                "0200017",
                "roll two dice",
                new string[] { "roll two dice"},
                "Rolls a given amount of dice.",
                (assistant, cmd, result) =>
                {
                    int first = _randomizer.Next(1, 6);
                    int second = _randomizer.Next(1, 6);
                    assistant.Speak("You rolled " + first + " and " + second + " for a total of " + (first + second));
                }));

            _afiliateCommands.Add(new Command(
                "0200018",
                "who are you",
                new string[] { "what are you" },
                "Gives some details about the assistant.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("I am " + assistant.Information.Name + ", and I am " + assistant.Information.Description);
                }));
            _afiliateCommands.Add(new Command(
                "0200019",
                "what version are you",
                new string[] { "what is your version" },
                "Presents the version of the assistant.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("My version is curently " + assistant.Information.Version);
                }));
            _afiliateCommands.Add(new Command(
                "0200020",
                "who is your owner",
                new string[] { "who do you serve", "who is your master", "what master do you serve" },
                "Presents the version of the assistant.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("I am owned by " + assistant.Information.Owner);
                }));

            _afiliateCommands.Add(new Command(
                "0200021",
                "mute",
                new string[] { "mute yourself", "recognition off", "microphone off" },
                "Presents the version of the assistant.",
                (assistant, cmd, result) =>
                {
                    assistant.formControl.MuteAssistant();
                }));

            _afiliateCommands.Add(new Command(
                "0200022",
                "close yourself",
                new string[] { "quit application","close system", "stop yourself" },
                "Closes Artemis",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Closing system. Goodbye " + assistant.Information.Owner);
                    assistant.formControl.Close();
                }));
        }
    }
}

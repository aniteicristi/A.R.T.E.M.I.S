using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.R.T.E.M.I.S
{
    internal sealed class TimeAndAgendaService : Service
    {
        public TimeAndAgendaService(AssistantBot assistant)
        {
            _afiliateCommands = new List<Command>();
            RegisterAfiliateCommands();
            assistant.formControl.timer.Tick += TimeEventListener;
        }

        protected override void RegisterAfiliateCommands()
        {
            _afiliateCommands.Add(new Command(
                "01001",
                "what time is it",
                new string[] { "tell me the time", "what's the time", "what is the time" },
                "Tells you the current time.",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("It's " + DateTime.Now.Hour + " and " + DateTime.Now.Minute + " o'clock");
                }));
            _afiliateCommands.Add(new Command(
                "01002",
                "what day is it",
                new string[] { "tell me what day it is", "what is today", "tell me the current date" },
                "Tells you the curent date",
                (assistant, cmd, result) => 
                {
                    assistant.Speak("Today is " + DateTime.Now.DayOfWeek + ", " + DateTime.Now.Day + ", " + DateTime.Now.Date.Month + ", " + DateTime.Now.Year);
                }));
            _afiliateCommands.Add(new Command(
                "01003",
                "show me my agenda",
                new string[] { "open my calendar", "open my agenda", "open calendar", "show calendar", "open agenda", "show agenda" },
                "Opens Google Callendar",
                (assistant, cmd, result) =>
                {
                    assistant.Speak("Opening your agenda. Hold on.");
                    System.Diagnostics.Process.Start("https://calendar.google.com/calendar/r");
                }));
        }

        private void TimeEventListener(object sender, EventArgs e)
        {
            
        }


    }
}

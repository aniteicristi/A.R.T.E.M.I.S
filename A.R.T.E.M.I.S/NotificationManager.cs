using System;
using System.Windows.Forms;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace A.R.T.E.M.I.S
{
    internal sealed class NotificationManager
    {
        AssistantBot _assistant;

        public NotificationManager(AssistantBot assistant)
        {
            _assistant = assistant;
        }

        internal void SendNotification()
        {
            throw new NotImplementedException();
        }
    }
}

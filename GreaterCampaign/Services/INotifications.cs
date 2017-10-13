using System;

namespace GreaterCampaign.Services
{
    public interface INotifications
    {
        void SetRepeatingReminderClick(object sender, EventArgs e, object data);
        void StopRepeatingReminderClick(object sender, EventArgs e);
    }
}

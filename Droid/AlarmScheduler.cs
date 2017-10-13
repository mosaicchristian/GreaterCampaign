using System;
using Android.App;
using Android.Content;

namespace GreaterCampaign.Droid
{
    public class AlarmScheduler
    {
        public AlarmScheduler()
        {
        }
		
        void ScheduleStockUpdates()
		{
			if (!IsAlarmSet())
			{
				//var alarm = (AlarmManager)this.GetSystemService(Context.AlarmService);

				//var pendingServiceIntent = PendingIntent.GetService(this, 0, stockServiceIntent, PendingIntentFlags.CancelCurrent);
				//alarm.SetRepeating(AlarmType.Rtc, 0, AlarmManager.IntervalHalfHour, pendingServiceIntent);
			}
		}

		bool IsAlarmSet()
		{
            return true;
			//return PendingIntent.GetBroadcast(this, 0, stockServiceIntent, PendingIntentFlags.NoCreate) != null;
		}
    }
}

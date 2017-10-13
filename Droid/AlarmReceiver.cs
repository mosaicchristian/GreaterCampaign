using System;
using Android.App;
using Android.Content;
//using Android.System;
using Android.Support.V4.App;

namespace GreaterCampaign.Droid
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class AlarmReceiver : BroadcastReceiver
    {
        int count = 0;
        public AlarmReceiver()
        {
            count = 0;
		}

        public override void OnReceive(Context context, Intent intent)
        {
			// When the user clicks the notification, SecondActivity will start up.
			Intent resultIntent = new Intent(context, typeof(MainActivity));

			// Construct a back stack for cross-task navigation:
			Android.App.TaskStackBuilder stackBuilder = Android.App.TaskStackBuilder.Create(context);
			stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));
			stackBuilder.AddNextIntent(resultIntent);

			// Create the PendingIntent with the back stack:            
			PendingIntent resultPendingIntent =
				stackBuilder.GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);

			// Build the notification:
			NotificationCompat.Builder builder = new NotificationCompat.Builder(context)
				.SetAutoCancel(true)                        // Dismiss from the notif. area when clicked
				.SetContentIntent(resultPendingIntent)      // Start 2nd activity when the intent is clicked.
				.SetContentTitle("GREATER Campaign")        // Set its title
				.SetNumber(count)                           // Display the count in the Content Info
				.SetSmallIcon(Resource.Drawable.icon)       // Display this icon
				.SetContentText(String.Format(
                    "Prayer Guide Reminder.  Pray for the GREATER campaign today.", count)); // The message to display.

			// Finally, publish the notification:
			NotificationManager notificationManager =
				(NotificationManager)context.GetSystemService(Context.NotificationService);
			notificationManager.Notify(100, builder.Build());

		}
    }
}

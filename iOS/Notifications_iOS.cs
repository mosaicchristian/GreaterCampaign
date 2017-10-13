using System;
using Xamarin.Forms;
using System.IO;
using GreaterCampaign.Services;
using GreaterCampaign.iOS;
using Foundation;
using UIKit;

[assembly: Dependency(typeof(Notifications_iOS))]

namespace GreaterCampaign.iOS
{
    public class Notifications_iOS : INotifications
    {
        public Notifications_iOS()
        {
        }

        public void SetRepeatingReminderClick(object sender, EventArgs e, object data)
		{
			// create the notification
			if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0) || UIDevice.CurrentDevice.CheckSystemVersion(11,0) )
			{
                // Get current notification settings
                UserNotifications.UNUserNotificationCenter.Current.GetNotificationSettings((settings) => {
					var alertsAllowed = (settings.AlertSetting == UserNotifications.UNNotificationSetting.Enabled);
                    Console.WriteLine("Alerts Allowed: " + alertsAllowed);
				});

                UserNotifications.UNUserNotificationCenter.Current.RequestAuthorization(UserNotifications.UNAuthorizationOptions.Alert, (approved, err) =>
                {
                    Console.WriteLine("Approval from iOS");
                });

                var content = new UserNotifications.UNMutableNotificationContent();
				content.Title = "GREATER Campaign";
				content.Subtitle = "Prayer Guide Reminder";
				content.Body = "Pray for the GREATER campaign today";
                content.Sound = UserNotifications.UNNotificationSound.Default;

                //var trigger = UserNotifications.UNTimeIntervalNotificationTrigger.CreateTrigger(30, false);
                //var trigger = UserNotifications.UNCalendarNotificationTrigger.CreateTrigger(5, false);
                //var date = new NSDate();
                //date.
                //var components = new NSDateComponents();
                //components.Minute = components.Minute + 1;
                //Console.WriteLine(components.Description);
                //var trigger = UserNotifications.UNCalendarNotificationTrigger.CreateTrigger(components, false);
                //NSDateComponents* components = [calendar components: NSCalendarUnitYear | NSCalendarUnitMonth | NSCalendarUnitDay | NSCalendarUnitHour | NSCalendarUnitMinute | NSCalendarUnitSecond | NSCalendarUnitTimeZone fromDate:[[NSDate date] dateByAddingTimeInterval: 10]];

                var components = new NSDateComponents();

                TimeSpan triggerTime = (TimeSpan)data;
                components.Hour = triggerTime.Hours;
                components.Minute = triggerTime.Minutes;

                // Set the trigger to repeat
                var trigger2 = UserNotifications.UNCalendarNotificationTrigger.CreateTrigger(components, true);
				var requestID = "greater";
				var request = UserNotifications.UNNotificationRequest.FromIdentifier(requestID, content, trigger2);

				UserNotifications.UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) => {
					if (err != null)
					{
						// Do something with error...
                        Console.WriteLine("Notification Error Encountered");
					}
				});

                UserNotifications.UNUserNotificationCenter.Current.AddNotificationRequestAsync(request);
			}
			else
			{
				var notification = new UILocalNotification();

				// set the fire date (the date time in which it will fire)
				notification.FireDate = NSDate.FromTimeIntervalSinceNow(60);

				// configure the alert
                notification.AlertAction = "Prayer Guide Reminder";
                notification.AlertBody = "Pray for the GREATER campaign today";

				// modify the badge
				notification.ApplicationIconBadgeNumber = 1;

				// set the sound to be the default sound
				notification.SoundName = UILocalNotification.DefaultSoundName;

				// schedule it
				UIApplication.SharedApplication.ScheduleLocalNotification(notification);
			}
		}

        public void StopRepeatingReminderClick(object sender, EventArgs e)
		{
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0) || UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                UserNotifications.UNUserNotificationCenter.Current.RemoveAllPendingNotificationRequests();
            }
		}

	}
}

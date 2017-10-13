using System;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Util;
using Android.Support.V4.App;

using GreaterCampaign.Services;
using GreaterCampaign.Droid;

[assembly: Dependency(typeof(MainActivity))]

namespace GreaterCampaign.Droid
{
    [Activity(Label = "GreaterCampaign.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, INotifications
    {
        // Alarm toast
        Toast repeating;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var size = new Xamarin.Forms.Size((int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density), (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density));
            Console.WriteLine(size.Height);
            Console.WriteLine(size.Width);

            App.screenSize.Width = size.Width;
            App.screenSize.Height = size.Height;

            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }

        public void SetRepeatingReminderClick (object sender, EventArgs e, object data)
        {
            // When the alarm goes off, we want to broadcast an Intent to our
            // BroadcastReceiver.  Here we make an Intent with an explicit class
            // name to have our own receiver (which has been published in
            // AndroidManifest.xml) instantiated and called, and then create an
            // IntentSender to have the intent executed as a broadcast.

            var context = Android.App.Application.Context;
            //Console.WriteLine( "Greater Campaign Notifiation 1: " + context);

            var intent = new Intent(Android.App.Application.Context, typeof(AlarmReceiver));
            var source = PendingIntent.GetBroadcast(Android.App.Application.Context, 0, intent, 0);

            // Create the alarm
            var am = (AlarmManager) Android.App.Application.Context.GetSystemService(AlarmService);

            TimeSpan triggerTime = (TimeSpan)data;

            // Construct the proper time to trigger the alarm
            Calendar calendar = Calendar.GetInstance(Java.Util.TimeZone.Default); //getInstance();
            //calendar.Set(CalendarField.Millisecond, DateTime.Now.Millisecond); //System.currentTimeMillis());
            calendar.Set(CalendarField.HourOfDay, triggerTime.Hours);
            calendar.Set(CalendarField.Minute, triggerTime.Minutes);

            // Schedule the alarm for a repeating time
            am.SetInexactRepeating(AlarmType.RtcWakeup, calendar.TimeInMillis, AlarmManager.IntervalDay, source);

            // Tell the user about what we did.
            if (repeating != null)
                repeating.Cancel ();
            repeating = Toast.MakeText (Android.App.Application.Context, "Greater Campaign Alarm Set", ToastLength.Long);
            repeating.Show();
        }

        public void StopRepeatingReminderClick (object sender, EventArgs e)
        {
            // Create the same intent and a matching IntentSender, for
            // the one that was scheduled.
            var intent = new Intent (Android.App.Application.Context, typeof (AlarmReceiver));
            var source = PendingIntent.GetBroadcast (Android.App.Application.Context, 0, intent, 0);

            // Cancel the alarm.
            var am = (AlarmManager) Android.App.Application.Context.GetSystemService (AlarmService);
            am.Cancel (source);

            // Tell the user about what we did.
            if (repeating != null)
                repeating.Cancel ();
            repeating = Toast.MakeText (Android.App.Application.Context, "Greater Campaign Reminder Disabled", ToastLength.Long);
            repeating.Show ();
        }
    }
}

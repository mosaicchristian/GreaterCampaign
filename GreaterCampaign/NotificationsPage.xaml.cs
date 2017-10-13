using System;
using System.Collections.Generic;
using GreaterCampaign.Services;

using Xamarin.Forms;

namespace GreaterCampaign
{
    public partial class NotificationsPage : ContentPage
    {
        public NotificationsPage()
        {
            InitializeComponent();

			var fileService = DependencyService.Get<ISaveAndLoad>();
			string fileName = "greater.txt";
			bool alreadyOpened = fileService.FileExists(fileName);
            bool setToggled = false;

            TimeSpan timeData = new TimeSpan(8,0,0);
            if( alreadyOpened )
            {
                TimeSpan readTime = fileService.GetTime(fileName);
                if( readTime.Hours != 0 || readTime.Minutes != 0 || readTime.Seconds != 0 )
                {
                    // If it isn't the default time, reset time data to the correct value
                    timeData = readTime;
                    setToggled = true;
                }
            }

			//
			// -------- SIZE/POSITION HELPERS -----------
			//
			var pddg_hdr_sl = new Thickness(0, 0, 0, 0);
            var pddg_hdr_sub_sl = new Thickness(40, 0, 0, 25);
			var pddg_mbody_top_sl = new Thickness(0, 50, 0, 0);
            var pddg_mbody_bot_sl = new Thickness(0, 10, 0, 10);
            var pddg_mbody_sl = new Thickness(40, 0, 40, 40);
			var pddg_foot_sl = new Thickness(0, 40, 0, 0);

            var lbl_dailynotifications_width = 200;
            var lbl_notificationtime_width = 200;
            var mbody_height_request = 250;
            var btn_done_width = 100;
            var footer_height_request = 100;
            var mrgn_switcher = new Thickness(0, 0, 10, 0);
            var mrgn_tp_notificationtime_picker = new Thickness(0, 0, 5, 0);
            var mrgn_img_greaterlogo = new Thickness(-20, -5, 0, 0);
            var mrgn_img_dividerline = new Thickness(0, 15, 0, 5);

			// -------- RESIZING -----------

			// iOS Changes
			if (Device.RuntimePlatform == Device.iOS && App.screenSize.Height > 600)
			{
				Console.WriteLine("Screen Size: " + App.screenSize.Height);
                pddg_mbody_sl = new Thickness(40, 40, 40, 40);
                mrgn_switcher = new Thickness(20, 0, -20, 0);
			}

			//
			// -------- HEADER -----------
			//

			Image img_GreaterLogo = new Image
			{
				//Aspect = Aspect.AspectFit,
				Source = ImageSource.FromFile("GREATER_Emblem2_115.png"),
				HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                Margin = mrgn_img_greaterlogo,
			};

			var header = new StackLayout
			{
				Padding = pddg_hdr_sl,
				Orientation = StackOrientation.Vertical,
			};

			header.Children.Add(img_GreaterLogo);

			Image img_Notification_heading = new Image
			{
				Aspect = Aspect.AspectFit,
				Source = ImageSource.FromFile("reminder_line.png"),
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,
			};

            var header_sub = new StackLayout
            {
                Padding = pddg_hdr_sub_sl,
            };

            header_sub.Children.Add(img_Notification_heading);
			
            //
			// -------- Main Body -----------
			//

            Label lbl_DailyNotifications_heading = new Label
            {
                FontSize = 16,
                Text = "Daily Reminder",
                FontFamily = "Helvetica",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = lbl_dailynotifications_width,
            };

            Switch switcher = new Switch
            {
                //BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                IsToggled = setToggled,
                Margin = mrgn_switcher,
            };
            switcher.Toggled += switcher_Toggled;

            var mainBody_top = new StackLayout
            {
				Padding = pddg_mbody_top_sl,
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.Black,
            };

            mainBody_top.Children.Add(lbl_DailyNotifications_heading);
            mainBody_top.Children.Add(switcher);

            Label lbl_NotificationTime_heading = new Label
            {
                FontSize = 16,
                Text = "Reminder Time",
                FontFamily = "Helvetica",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = lbl_notificationtime_width,
            };

            TimePicker tp_NotificationTime_picker = new TimePicker
            {
                Time = timeData,
                TextColor = Color.White,
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                //Margin = mrgn_tp_notificationtime_picker,
            };

            var mainBody_bot = new StackLayout
            {
				Padding = pddg_mbody_bot_sl,
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.Black,
            };

            mainBody_bot.Children.Add(lbl_NotificationTime_heading);
            mainBody_bot.Children.Add(tp_NotificationTime_picker);

			var mainBody = new StackLayout
			{
				Padding = pddg_mbody_sl,
				Orientation = StackOrientation.Vertical,
				BackgroundColor = Color.Black,
                HeightRequest = mbody_height_request,
			};

			Image img_Divider = new Image
			{
				//Aspect = Aspect.AspectFit,
				Source = ImageSource.FromFile("divider_line.png"),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
                Margin = mrgn_img_dividerline,
			};

            mainBody.Children.Add(mainBody_top);
            mainBody.Children.Add(img_Divider);
            mainBody.Children.Add(mainBody_bot);

			var mainBody_scrollView = new ScrollView { Content = mainBody };

			//
			// -------- FOOTER -----------
			//

			Button btn_Done = new Button
            {
                Text = "SAVE",
                TextColor = Color.Black,
                //FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 1,
                WidthRequest = btn_done_width,
                MinimumWidthRequest = btn_done_width,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BorderRadius = 0,
            };

            btn_Done.Clicked += async (sender, args) =>
            {
                var setNotificationService = DependencyService.Get<INotifications>();

                // check if the notification switcher is true or false
                Console.WriteLine("Switcher Toggled On: " + switcher.IsToggled);

                if( switcher.IsToggled )
                {
                    // swticher is toggled 'on', set the reminder
                    setNotificationService.SetRepeatingReminderClick(this, null, (object)tp_NotificationTime_picker.Time);
                    await fileService.SaveTextAsync(fileName, "Reminder\n" + tp_NotificationTime_picker.Time.ToString() );
                }
                else
                {
                    // switcher is toggled 'off', remove the reminder
                    setNotificationService.StopRepeatingReminderClick(this, null);
                    await fileService.SaveTextAsync(fileName, "");
                }

                /*
                if( Device.RuntimePlatform == Device.Android ) {
                    Console.WriteLine("Android Notification Possibly Set");
                }
                else if( Device.RuntimePlatform == Device.iOS ) {
                    Console.WriteLine("iOS Notification Possibly Set");
                }*/
                    
                await Navigation.PushModalAsync(new DaysCarouselPage(), false);
            };

            var footer = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.White,
                HeightRequest = footer_height_request,
                Padding = pddg_foot_sl, 
            };

            footer.Children.Add(btn_Done);

			//
			// -------- FINAL -----------
			//

			this.Content = new StackLayout 
            { 
                Children = {
                    header,
                    header_sub,
                    mainBody_scrollView,
                    footer,
                }
            };
        }

        void switcher_Toggled(object sender, ToggledEventArgs e)
        {
            //label.Text = String.Format("Switch is now {0}", e.Value);
            //lbl_NotificationSwitcher_test.Text = "Switcher Pushed";
            Console.WriteLine("Switcher Changed");
        }

    }
}

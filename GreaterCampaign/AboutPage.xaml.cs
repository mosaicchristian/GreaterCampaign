using System;

using Xamarin.Forms;

namespace GreaterCampaign
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
			InitializeComponent();

			//
			// -------- SIZE/POSITION HELPERS -----------
			//
			var pddg_hdr_sl = new Thickness(0, 0, 0, 0);
			var pddg_mbody_sl = new Thickness(40, 0, 40, 20);
            var pddg_foot_sl = new Thickness(10, 5, 10, 5);
			var mrgn_lbl_about_hdg = new Thickness(0, 0, 0, 10);
            var mrgn_lbl_about_txt = new Thickness(0, 10, 0, 10);
            var mrgn_lbl_read_txt = new Thickness(0, 0, 0, 10);
            var pddg_page = new Thickness(0, 0, 0, 0);

            var btn_notification_width = 150;
            var btn_start_width = 75;
            var mrgn_img_greaterlogo = new Thickness(-20, -20, 0, 0);

			//
			// -------- HEADER -----------
			//

			Image img_GreaterLogo = new Image
			{
				Source = ImageSource.FromFile("GREATER_Emblem2_115.png"),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                Margin = mrgn_img_greaterlogo,
			};

			var header = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				BackgroundColor = Color.White,
			};
			header.Children.Add(img_GreaterLogo);


            //
            // -------- Main Body -----------
            //

            Label lbl_About_heading = new Label
            {
                FontSize = 22,
                Text = "About",
                TextColor = Color.Black,
                Margin = mrgn_lbl_about_hdg,
            };

			Image img_About_heading = new Image
			{
				Aspect = Aspect.AspectFit,
				Source = ImageSource.FromFile("about_line.png"),
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,
			};

            Label lbl_About_txt = new Label
            {
                FontSize = 14,
                FontFamily = "Helvetica",
                Text = "This prayer guide is designed to be used for 14 days during Mosaic's GREATER campaign.  How to use it:",
                TextColor = Color.Gray,
                Margin = mrgn_lbl_about_txt,
            };

            Label lbl_read_heading = new Label
            {
                FontSize = 18,
                FontFamily = "Helvetica",
                Text = "read",
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
            };

            Label lbl_read_txt = new Label
            {
                FontSize = 14,
                FontFamily = "Helvetica",
                Text = "Read the scripture aloud.  You may also find it helpful to read the surrounding verses to better understand the context.",
                TextColor = Color.Gray,
				Margin = mrgn_lbl_read_txt,
			};

            Label lbl_pray_heading = new Label
            {
                FontSize = 18,
                FontFamily = "Helvetica",
                Text = "pray",
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
            };

            Label lbl_pray_txt = new Label
            {
                FontSize = 14,
                FontFamily = "Helvetica",
                Text = "Communicate with God.  Talk with Him like you would a friend.  Listen as much as you speak.",
                TextColor = Color.Gray,
            };

            var mainBody = new StackLayout
            {
                Padding = pddg_mbody_sl,
                Orientation = StackOrientation.Vertical,
            };

            mainBody.Children.Add(img_About_heading);
            mainBody.Children.Add(lbl_About_txt);
            mainBody.Children.Add(lbl_read_heading);
            mainBody.Children.Add(lbl_read_txt);
            mainBody.Children.Add(lbl_pray_heading);
            mainBody.Children.Add(lbl_pray_txt);

			//
			// -------- FOOTER -----------
			//

			Button btn_Notifications = new Button
            {
                Text = "SET REMINDER",
                FontFamily = "Helvetica",
                TextColor = Color.Black,
                //FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 1,
                MinimumWidthRequest = btn_notification_width,
                WidthRequest = btn_notification_width,
                BorderRadius = 0,
            };
            btn_Notifications.Clicked += async (sender, args) =>
			{
				await Navigation.PushModalAsync(new NotificationsPage(), false);
			};

            Button btn_Start = new Button
            {
                Text = "START",
                FontFamily = "Helvetica",
                TextColor = Color.White,
                //FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.Black,
                BorderColor = Color.White,
                BorderWidth = 1,
                MinimumWidthRequest = btn_start_width,
                WidthRequest = btn_start_width,
                BorderRadius = 0,
            };
			btn_Start.Clicked += async (sender, args) =>
			{
				await Navigation.PushModalAsync(new DaysCarouselPage(), false);
			};

            var footer = new StackLayout
            {
                Padding = pddg_foot_sl,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
            };

            footer.Children.Add(btn_Notifications);
            footer.Children.Add(btn_Start);

			//
			// -------- FINAL -----------
			//

			this.Content = new StackLayout 
            { 
                Children = {
                    header,
                    mainBody,
                    footer,
                } 
            };
            this.Padding = pddg_page;

        }
    }
}

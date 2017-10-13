using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

namespace GreaterCampaign
{
    public partial class DayPage : ContentPage
    {
        public CampaignData dataStore = null;

        Label lbl_Read_header = null;
        Label lbl_Read_text = null;
        Label lbl_Pray_header = null;
        Label lbl_Pray_text = null;
        Label lbl_Extra_text = null;
        Label lbl_Date_text = null;
        int tapCount = 0;

        public DayPage()
        {
            InitializeComponent();
            dataStore = new CampaignData();

			//
			// -------- SIZE/POSITION HELPERS -----------
			//
			var pddg_hdr_sl = new Thickness(20, 20, 5, 5);
			var pddg_mbody_sl = new Thickness(40, 40, 40, 40);
			var pddg_foot_sl = new Thickness(10, 5, 10, 5);
            var mrgn_mbody_sl = new Thickness(0, -10, 0, 0);
            var mrgn_lbl_read_hdr = new Thickness(0, 0, 0, 2);
			var mrgn_lbl_read_txt = new Thickness(0, 0, 0, 10);
			var mrgn_lbl_pray_hdr = new Thickness(0, 0, 0, 2);

            var hdr_height_request = 110;
            var mainbody_height_request = 300;
            var mainbody_minimum_height_request = 300;
            var mrgn_img_alarm = new Thickness(0, 15, 15, 0);
            var mrgn_img_greater_text = new Thickness(20, 5, 0, 0);

			//
			// -------- HEADER -----------
			//

			Image notificationIcon = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromFile("alarmclock_144.png"),
                WidthRequest = 25,
                HeightRequest = 25,
                MinimumHeightRequest = 25,
                MinimumWidthRequest = 25,
                HorizontalOptions = LayoutOptions.End,
                Margin = mrgn_img_alarm,
            };

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) => {
                OnTapGestureRecognizerTapped(s, e);
			};
            notificationIcon.GestureRecognizers.Add(tapGestureRecognizer);

			Image img_Greater_heading = new Image
			{
				//Aspect = Aspect.AspectFit,
				Source = ImageSource.FromFile("greater_line.png"),
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,
                Margin = mrgn_img_greater_text,
			};

			var header = new StackLayout
			{
				Padding = pddg_hdr_sl,
				Orientation = StackOrientation.Vertical,
				HeightRequest = hdr_height_request,
				BackgroundColor = Color.FromHex("FCEF44"),
				//HorizontalOptions = LayoutOptions.End,
			};

			header.Children.Add(notificationIcon);
            header.Children.Add(img_Greater_heading);

            //
            // -------- Main Body -----------
            //

            lbl_Read_header = new Label
            {
                FontSize = 18,
                FontFamily = "Helvetica",
                FontAttributes = FontAttributes.Bold,
                Text = "read",
                TextColor = Color.White,
                //TextColor = Color.FromHex("BCBCBC"),
                Margin = mrgn_lbl_read_hdr,
            };

            lbl_Read_text = new Label
            {
                FontSize = 14,
                FontFamily = "Helvetica",
                Text = "",
                TextColor = Color.White,
                Margin = mrgn_lbl_read_txt,
            };

            lbl_Pray_header = new Label
            {
                FontSize = 18,
                FontFamily = "Helvetica",
                FontAttributes = FontAttributes.Bold,
                Text = "pray",
                TextColor = Color.White,
                Margin = mrgn_lbl_pray_hdr,
            };

            lbl_Pray_text = new Label
            {
                FontSize = 14,
                Text = "",
                TextColor = Color.White,
            };

            lbl_Extra_text = new Label
            {
                FontSize = 14,
                Text = "",
                TextColor = Color.White,
            };

            var mainBody = new StackLayout
            {
                Padding = pddg_mbody_sl,
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Black,
                HeightRequest = mainbody_height_request,
                MinimumHeightRequest = mainbody_minimum_height_request,
                //HeightRequest = 250,
                Margin = mrgn_mbody_sl,
            };

            mainBody.Children.Add(lbl_Read_header);
            mainBody.Children.Add(lbl_Read_text);
            mainBody.Children.Add(lbl_Pray_header);
            mainBody.Children.Add(lbl_Pray_text);
            mainBody.Children.Add(lbl_Extra_text);

            var mainBody_scrollView = new ScrollView
            {
                Content = mainBody,
            };

			//
			// -------- FOOTER -----------
			//

			lbl_Date_text = new Label
			{
				FontSize = 18,
                FontFamily = "Helvetica",
				Text = "Day",
				TextColor = Color.FromHex("B5B5B5"),
			};

            var footer = new StackLayout
            {
                Padding = pddg_foot_sl,
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
			};

			footer.Children.Add(lbl_Date_text);

			//
			// -------- FINAL -----------
			//

			// Build this page
			this.Content = new StackLayout
            {
                Children = {
                    header,
                    mainBody,
                    //mainBody_scrollView,
                    footer,
                }
            };
        }

        public DayPage(Item item) : this()
        {
            lbl_Read_text.Text = item.Read;
            lbl_Pray_text.Text = item.Pray;
            lbl_Date_text.Text = item.Date;
        }

        public void setData(Item item)
        {
            //DayPage();
            lbl_Read_text.Text = item.Read;
            lbl_Pray_text.Text = item.Pray;
            lbl_Date_text.Text = item.Date;
        }

		async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
		{
			tapCount++;
			var imageSender = (Image)sender;
            //lbl_Extra_text.Text = "Button Pressed " + tapCount;
            await Navigation.PushModalAsync(new NotificationsPage(), false);
		}
    }
}
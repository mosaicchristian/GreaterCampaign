using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GreaterCampaign
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();

            //
            // -------- SIZE/POSITION HELPERS -----------
            //
            var pddg_hdr_sl = new Thickness(0, 0, 0, 0);
            var pddg_mbody_sl = new Thickness(40, 40, 40, 40);
            //var pddg_footer_sl = new Thickness(40, 0, 40, 20);
            var mrgn_lbl_splash_txt = new Thickness(0, 0, 0, 20);

            var header_height_request = 250;
            var btn_start_width_request = 50;
            var mrgn_img_greaterlogowemblem = new Thickness(0, 40, 0, 0);

            // -------- RESIZING -----------

            // iOS Changes
            if( Device.RuntimePlatform == Device.iOS && App.screenSize.Height > 600 )
            {
                Console.WriteLine("Screen Size: " + App.screenSize.Height);
                header_height_request = 350;
                mrgn_img_greaterlogowemblem = new Thickness(0, 100, 0, 0);
            }

			//
			// -------- HEADER -----------
			//

			Image img_GreaterLogoWEmblem = new Image
            {
                //Aspect = Aspect.AspectFit,
                Source = ImageSource.FromFile("GREATER_LogoWEmblem_200.png"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = mrgn_img_greaterlogowemblem,
			};

            var header = new StackLayout()
            {
                Padding = pddg_hdr_sl,
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromHex("FCEF44"),
                HeightRequest = header_height_request,
				//HorizontalOptions = LayoutOptions.End,
            };

            header.Children.Add(img_GreaterLogoWEmblem);

			//
			// -------- Main Body -----------
			//

			Label lbl_Splash_txt = new Label
			{
				FontSize = 14,
                FontFamily = "Helvetica",
				Text = "Thanks for studying the Bible and praying about the GREATER campaign.  We are excited to see what God does as we move into a larger facility to reach more people with the truth.",
				TextColor = Color.Gray,
                Margin = mrgn_lbl_splash_txt,
			};

			Button btn_Start = new Button
			{
				Text = "NEXT",
				FontFamily = "Helvetica",
				//FontAttributes = FontAttributes.Bold,
				TextColor = Color.Black,
				BackgroundColor = Color.White,
				BorderColor = Color.Black,
				BorderWidth = 1,
				MinimumWidthRequest = btn_start_width_request,
				WidthRequest = btn_start_width_request,
				BorderRadius = 0,
			};

			btn_Start.Clicked += async (sender, args) =>
			{
				await Navigation.PushAsync(new AboutPage(), false);
			};

			var mainBody = new StackLayout
			{
				Padding = pddg_mbody_sl,
				Orientation = StackOrientation.Vertical,
			};

			mainBody.Children.Add(lbl_Splash_txt);
			mainBody.Children.Add(btn_Start);

			//
			// -------- FOOTER -----------
			//

			//var footer = new StackLayout
			//{
                //Padding = pddg_footer_sl,
			//	Orientation = StackOrientation.Vertical,
			//};

            //footer.Children.Add(btn_Start);

			//
			// -------- FINAL -----------
			//

			this.Content = new StackLayout
            {
                Children = {
                    header,
                    mainBody,
                    //footer
                }
            };

        } // end SplashPage()
    }
}

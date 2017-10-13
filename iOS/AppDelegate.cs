using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

using Foundation;
using UIKit;

namespace GreaterCampaign.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

			var size = new Size(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);
			Console.WriteLine(size.Height);
			Console.WriteLine(size.Width);

			App.screenSize.Width = size.Width;
			App.screenSize.Height = size.Height;

            LoadApplication(new App());

            // https://forums.xamarin.com/discussion/62450/how-can-i-customize-the-color-in-switch
            UISwitch.Appearance.TintColor = UIColor.FromRGB(255, 255, 255);
			UISwitch.Appearance.OnTintColor = UIColor.FromRGB(251, 243, 102);

            return base.FinishedLaunching(app, options);
        }
    }
}

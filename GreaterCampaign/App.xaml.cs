using System;
using GreaterCampaign.Services;

using Xamarin.Forms;

namespace GreaterCampaign
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static Size screenSize = new Size(0, 0);

        public App()
        {
            InitializeComponent();

            var fileService = DependencyService.Get<ISaveAndLoad> ();
            string fileName = "greater.txt";
            bool alreadyOpened = fileService.FileExists (fileName);

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
            {
                if (alreadyOpened)
                {
                    //MainPage = new NavigationPage(new DaysCarouselPage());
                    MainPage = new DaysCarouselPage();
                }
                else {
                    // this could be moved to the opening page with an 'await' after clicking a button
                    fileService.SaveTextAsync (fileName, "");
                    MainPage = new NavigationPage(new SplashPage());
                }
            }
            else
            {
                if (alreadyOpened)
                {
                    //MainPage = new NavigationPage(new DaysCarouselPage());
                    MainPage = new DaysCarouselPage();
                }
                else {
                    fileService.SaveTextAsync(fileName, "");
                    MainPage = new NavigationPage(new SplashPage());
                }
            }
                
        } // end App()
    } // end class
} // end namespace

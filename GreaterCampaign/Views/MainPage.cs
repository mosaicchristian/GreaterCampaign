using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace GreaterCampaign
{
    //public class MainPage : TabbedPage
    public class MainPage : ContentPage
    {
        Page aboutPage, splashPage, dayPage = null, notificationsPage = null;

        public MainPage()
        {
            //Page itemsPage, aboutPage, splashPage, dayPage = null, notificationsPage = null;
            //CampaignData dataStore = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    //itemsPage = new NavigationPage(new ItemsPage())
                    //{
                    //    Title = "Browse"
                    //};

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };

                    splashPage = new NavigationPage(new SplashPage())
                    {
                        Title = "Splash"
                    };

                    dayPage = new NavigationPage(new DaysCarouselPage())
                    {
                        Title = "Item Carousel"
                    };

                    notificationsPage = new NavigationPage(new NotificationsPage())
                    {
                        Title = "Notifications"
                    };

                    //itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    splashPage.Icon = "tab_about.png";
                    dayPage.Icon = "tab_feed.png";
                    notificationsPage.Icon = "tab_feed.png";

                    //MainPage = new NavigationPage( new SplashPage() );
                    break;
                default:
                    notificationsPage = new NotificationsPage()
                    {
                        Title = "Notifications"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };

                    splashPage = new SplashPage()
                    {
                        Title = "Splash"
                    };
                    break;
            }

            //Children.Add(aboutPage);
            //Children.Add(splashPage);
            //Children.Add(dayPage);
            //Children.Add(notificationsPage);

            //Title = Children[0].Title;
        }

        //protected override void OnCurrentPageChanged()
        //{
        //    base.OnCurrentPageChanged();
        //    Title = CurrentPage?.Title ?? string.Empty;
        //}

        public void setPage_Notifications()
        {
            //CurrentPage = new NavigationPage( new NotificationsPage() );
        }
    }
}

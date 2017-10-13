using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace GreaterCampaign
{
    public partial class DaysCarouselPage : CarouselPage
    {
        public CampaignData dataStore = null;

        public DaysCarouselPage()
        {
            InitializeComponent();

            dataStore = new CampaignData();
            List<ContentPage> pages = new List<ContentPage>(0);
			
            foreach (var item in dataStore.getItems() )
			{
                pages.Add(new DayPage(item));
			}

            // TODO: Correct current to be the current day
            //DateTime current = DateTime.Now;
            //DateTime current = new DateTime(2017, 10, 30);
            DateTime current = new DateTime(2017, 11, 12);

            DateTime start = new DateTime(2017, 10, 29);
            DateTime end = new DateTime(2017, 11, 12);

            // add 1 for each day beyond start; add an extra day so that on 
            // 22nd the first day appears
            // ex) Oct 23 - Oct 22 = 1; it should really be 2
            TimeSpan fromStart = current.Subtract(start);
            var availableDays = fromStart.Days + 1;

            for (int i = 0; i < pages.Count && i < availableDays; i++ ) 
            {
                Children.Add(pages[i]);
            }

            // set the page to the 'current' day
            this.CurrentPage = this.Children[this.Children.Count - 1];
        }
    }
}

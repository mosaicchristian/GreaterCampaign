﻿using System;
using System.Collections.Generic;
using System.Linq;
using GreaterCampaign.Services;

using Foundation;
using UIKit;

//[assembly: Dependency(typeof(Application))]

namespace GreaterCampaign.iOS
{
    public class Application //: INotifications
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
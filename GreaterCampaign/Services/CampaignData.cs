using System;
using System.Collections.Generic;

namespace GreaterCampaign
{
    public class CampaignData
    {

        List<Item> items;

        public CampaignData()
        {
			items = new List<Item>();
			var mockItems = new List<Item>
			{
				new Item { Id = 1, Date = "Oct 29", Read = "John 3:30", Pray="John is humbly declaring that it is sufficient honor if he is permitted to point broken people to Jesus, making Jesus (and only Jesus) greater.  Ask God to give Mosaic this attitude as the GREATER campaign begins.  Ask Him to show you how you can become less." },
                new Item { Id = 2, Date = "Oct 30", Read = "Matthew 6:6-8", Pray="Prayer is personal, intimate communication with God. God longs for you to spend time with Him and for you to be brutally honest with Him. Ask God to teach you how to pray more faithfully and honestly. Because our theme verse is John 3:30, spend 3 minutes and 30 seconds in silence listening to Him." },
				new Item { Id = 3, Date = "Oct 31", Read = "Luke 5:26", Pray="To see God do great things, you must ask Him to do great things.  Pray for Mosaic to see great things. Pray that God would continue to lead us to be a church that passionately, recklessly, and sacrificially shares His message of freedom with the hurting world around us." },
				new Item { Id = 4, Date = "Nov 1", Read = "Hebrews 11:1", Pray="If you read through the rest of Hebrews 11, you’ll read story after story of people that did crazy things based on a confidence in things they couldn’t see. Faith always leads to action. What is God asking you to do? Ask Him." },
				new Item { Id = 5, Date = "Nov 2", Read = "Matthew 6:9", Pray="Praise God for his greatness and holiness. Thank God for trusting you with the huge responsibility of representing Him to those that don’t yet follow Him. Commit to using your time, money, and talents to make Jesus greater." },
				new Item { Id = 6, Date = "Nov 3", Read = "Joshua 3:5, Psalm 51:10", Pray="Ask God to clearly show you the areas of your life where you aren’t following Him. Ask Him to forgive you and transform you. Pray for God to work in the hearts of all those that currently attend Mosaic - that He would show us our brokenness and give us His vision for a better way." },
                new Item { Id = 7, Date = "Nov 4", Read = "Psalms 119:104-106", Pray="Thank God for the Bible and for connecting with you through it. Ask Him for the courage to follow the path that it outlines for your life.  Ask Him to give you a “me too” attitude when sharing His truth and grace with those around you." }, 
                new Item { Id = 8, Date = "Nov 5", Read = "Romans 15:4-5", Pray="Commit today to read the Bible daily if you’re not already doing it.  Thank God for the hope, encouragement, and patience that come from reading the Bible.  Continue to ask Him what steps you need to take to be faithful in your actions, finances, and relationships." },
                new Item { Id = 9, Date = "Nov 6", Read = "1 John 5:14-15", Pray="Acknowledge God’s amazing power. Ask God to help you see things the way He sees them, to understand how much He loves those that are still far from Him, and to become passionate about reaching people with the message of hope.  Ask with boldness." },
                new Item { Id = 10, Date = "Nov 7", Read = "1 John 4:10-12", Pray="Did you catch that? The best way for people that are far from God to see Him is for those of us who are followers of Jesus to love each other.  Thank God for the people who have shown you love.  Ask God to show you who you need to love today." },
                new Item { Id = 11, Date = "Nov 8", Read = "Mark 10:44-45", Pray="What motivated Jesus to come to earth? You did. Did He come to be served? No. Did He come to serve? Yes. Ask God to help your response to His love and service be the same - to love and serve others. Ask Him for a clear vision of how you can help others through serving at Mosaic." },
                new Item { Id = 12, Date = "Nov 9", Read = "1 John 1:2", Pray="Thank God for how He has impacted your life. Ask Him to help you tell others your story and to teach you how to declare the truth of Jesus’ gospel to a world full of broken people." },
                new Item { Id = 13, Date = "Nov 10", Read = "Peter 1:7-8", Pray="Ask God to help you put self-interests aside and go all out serving Him and others so that you can be filled with His “inexpressible joy.” Ask Him to help Mosaic experience this kind of joy as we make Jesus greater and we become less." },
                new Item { Id = 14, Date = "Nov 11", Read = "Ephesians 2:4-5", Pray="Praise God for showing you mercy and giving you life.  Pray that those far from God would see and understand God’s mercy and be given life in Christ as a direct result of the generosity of Mosaic during the GREATER campaign." },
            };

			foreach (var item in mockItems)
			{
				items.Add(item);
			}
        }

        public List<Item> getItems()
        {
            return items;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RedBinkieResearchLabs
{

    //Shared class to build the menu across all layouts
    public class clsMenu
    {
        public Activity activity;

        public clsMenu(Activity _activity)
        {
            this.activity = _activity;
            //other initializations...
        }

        public void buildMenu()
        {
            //attach event to the menu item Home
            var menuButtonHome = this.activity.FindViewById(RedBinkieResearchLabs.Resource.Id.textViewHome);
            menuButtonHome.Click += (sender, e) => {
                this.activity.StartActivity(typeof(MainActivity));
            };

            //attach event to the menu item Self Service
            var menuButtonSS = this.activity.FindViewById(RedBinkieResearchLabs.Resource.Id.textSelfService);
            menuButtonSS.Click += (sender, e) => {
                this.activity.StartActivity(typeof(SelfServiceActivity));
            };

            //attach event to the menu item Contact Us
            var menuButtonCU = this.activity.FindViewById(RedBinkieResearchLabs.Resource.Id.textContactus);
            menuButtonCU.Click += (sender, e) => {
                this.activity.StartActivity(typeof(activityContactUs));
            };

        }

        public void buildMenuMain()
        {
            var menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainer);
            var menuButton = this.activity.FindViewById(RedBinkieResearchLabs.Resource.Id.MenuButton);
            menuButton.Click += (sender, e) => {
                menu.AnimatedOpened = !menu.AnimatedOpened;
            };
        }
        public void buildMenuSelfService()
        {
            var menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainerSS);
            var menuButton = this.activity.FindViewById(RedBinkieResearchLabs.Resource.Id.MenuButton);
            menuButton.Click += (sender, e) => {
                menu.AnimatedOpened = !menu.AnimatedOpened;
            };
        }
        public void buildMenuContactUs()
        {
            var menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainerContact);
            var menuButton = this.activity.FindViewById(RedBinkieResearchLabs.Resource.Id.MenuButton);
            menuButton.Click += (sender, e) => {
                menu.AnimatedOpened = !menu.AnimatedOpened;
            };
        }
    }
}
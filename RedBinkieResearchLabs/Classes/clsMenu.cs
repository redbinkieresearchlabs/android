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
            var menuButtonSS = this.activity.FindViewById(RedBinkieResearchLabs.Resource.Id.linearMenu3);
            menuButtonSS.Click += (sender, e) => {
                this.activity.StartActivity(typeof(SelfServiceActivity));
            };

            //attach event to the menu item Contact Us
            var menuButtonCU = this.activity.FindViewById(RedBinkieResearchLabs.Resource.Id.linearMenu4);
            menuButtonCU.Click += (sender, e) => {
                this.activity.StartActivity(typeof(activityContactUs));
            };

            //attach event to the menu item Disclaimer
            var menuButtonDisclaimer = this.activity.FindViewById(RedBinkieResearchLabs.Resource.Id.linearDisc);
            menuButtonDisclaimer.Click += (sender, e) => {
                this.activity.StartActivity(typeof(activityDisclaimer));
            };

            //attach event to the menu item Disclaimer
            var menuButtonWorks = this.activity.FindViewById(RedBinkieResearchLabs.Resource.Id.linearWorks);
            menuButtonWorks.Click += (sender, e) => {
                this.activity.StartActivity(typeof(activityWorks));
            };

            //attach event to the menu item Log a fault
            var menuButtonFault = this.activity.FindViewById(RedBinkieResearchLabs.Resource.Id.linearFault);
            menuButtonFault.Click += (sender, e) => {
                this.activity.StartActivity(typeof(activityLogFault));
            };

        }

        public void buildMenuIndividual(int menuSelected=0)
        {
            var menu= this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainer); //default is home
             
            switch (menuSelected)
            {
                case 0: //home
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainer);
                    break;
                case 1: //profile
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainer);
                    break;
                case 2: //bills
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainer);
                    break;
                case 3: //self service
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainerSS);
                    break;
                case 4: //notifications
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainer);
                    break;
                case 5: //fault
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainerFault);
                    break;
                case 6: //works
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainerWorks);
                    break;
                case 7: //whats new
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainer);
                    break;
                case 8: //contact us
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainerContact);
                    break;
                case 9: //settings
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainer);
                    break;
                case 10: //disclaimer
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainerDisclaimer);
                    break;
                case 11: //about us
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainer);
                    break;
                case 12: //logout
                    menu = this.activity.FindViewById<RedBinkieResearchLabs.FlyOutContainer>(RedBinkieResearchLabs.Resource.Id.FlyOutContainer);
                    break;
            }

            var menuButton = this.activity.FindViewById(RedBinkieResearchLabs.Resource.Id.MenuButton);
            menuButton.Click += (sender, e) => {
                menu.AnimatedOpened = !menu.AnimatedOpened;
            };
        }
    }
}
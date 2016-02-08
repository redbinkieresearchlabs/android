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
    [Activity(Label = "activityContactUs")]
    public class activityContactUs : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.layoutContactUs);

            var menu = FindViewById<FlyOutContainer>(Resource.Id.FlyOutContainerContact);
            var menuButton = FindViewById(Resource.Id.MenuButton);
            menuButton.Click += (sender, e) => {
                menu.AnimatedOpened = !menu.AnimatedOpened;
            };

            //attach event to the menu item Home
            var menuButtonHome = FindViewById(Resource.Id.textViewHome);
            menuButtonHome.Click += (sender, e) => {
                StartActivity(typeof(MainActivity));
            };

            //attach event to the menu item Self Service
            var menuButtonSS = FindViewById(Resource.Id.textSelfService);
            menuButtonSS.Click += (sender, e) => {
                StartActivity(typeof(SelfServiceActivity));
            };

            //attach event to the menu item Contact Us
            var menuButtonCU = FindViewById(Resource.Id.textContactus);
            menuButtonCU.Click += (sender, e) => {
                StartActivity(typeof(activityContactUs));
            };
        }
    }
}
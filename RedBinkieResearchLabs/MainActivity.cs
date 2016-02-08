﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RedBinkieResearchLabs
{
//    [Activity(Label = "RedBinkieResearchLabs", MainLauncher = true, Icon = "@drawable/icon")]
    [Activity(Label = "Wessex Water Services Ltd")]

    public class MainActivity : Activity
    {
 //       int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            TextView messageText = FindViewById<TextView>(Resource.Id.welcomeMessage);
            messageText.Text = "Welcome " + sharedPref.GetPreference(Application.Context,"uname","");

            var menu = FindViewById<FlyOutContainer>(Resource.Id.FlyOutContainer);
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

        }
    }
}


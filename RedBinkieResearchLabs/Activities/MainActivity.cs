using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RedBinkieResearchLabs
{
//    [Activity(Label = "RedBinkieResearchLabs", MainLauncher = true, Icon = "@drawable/icon")]
    [Activity(Theme = "@android:style/Theme.NoTitleBar")]

    public class MainActivity : Activity
    {
        //       int count = 1;
        ISharedPreferences prefs = Application.Context.GetSharedPreferences("FlowPref", FileCreationMode.Private);
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (prefs.GetString("uname", null) == null) //no user account exists, dont force your way in
            {
                StartActivity(typeof(doLogin));
            }

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            SetProfile(); //get the profile data and put it under preferences
            TextView username = FindViewById<TextView>(RedBinkieResearchLabs.Resource.Id.textUserName);
            username.Text = prefs.GetString("fullname", null);

            //build the menu
            clsMenu menu = new clsMenu(this);
            menu.buildMenuIndividual(0);
            menu.buildMenu();

        }

        private void SetProfile()
        {
            clsGetProfile objGetProfile = new clsGetProfile();
            objGetProfile.GetProfile(prefs.GetString("uid", null));
        }
    }
}


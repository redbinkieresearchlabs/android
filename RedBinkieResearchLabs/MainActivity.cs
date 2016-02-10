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

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            TextView messageText = FindViewById<TextView>(Resource.Id.welcomeMessage);
            messageText.Text = "Hello Asrar Makrani";// + sharedPref.GetPreference(Application.Context,"uname","");

            //build the menu
            clsMenu menu = new clsMenu(this);
            menu.buildMenuIndividual(0);
            menu.buildMenu();
        }
    }
}


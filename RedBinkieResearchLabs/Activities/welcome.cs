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

using Java.IO;

namespace RedBinkieResearchLabs.Activities
{
    [Activity(Label = "Flow", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar")]
    public class welcome : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.welcome);

            TextView btnLogin = FindViewById<TextView>(Resource.Id.lnkLogin);
            btnLogin.Click += delegate
            {
                StartActivity(typeof(doLogin));
            };

            File f = new File("/data/data/RedBinkieResearchLabs.RedBinkieResearchLabs/shared_prefs/FlowPref.xml");

            if(f.Exists())
            {
                //check if there is a uname already existing
                ISharedPreferences prefs = Application.Context.GetSharedPreferences("FlowPref", FileCreationMode.Private);
                if(prefs.GetString("uname", null) != null)
                {
                    StartActivity(typeof(MainActivity));
                }
            }
        }
    }
}
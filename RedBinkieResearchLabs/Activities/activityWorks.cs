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
using Android.Webkit;

namespace RedBinkieResearchLabs
{
    [Activity(Theme = "@android:style/Theme.NoTitleBar")]
    public class activityWorks : Activity
    {
        WebView worksView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.layoutWorks);

            //build the menu
            clsMenu menu = new clsMenu(this);
            menu.buildMenuIndividual(6);
            menu.buildMenu();

            //load the website in teh webview
            worksView = FindViewById<WebView>(Resource.Id.webView1);
            worksView.Settings.JavaScriptEnabled = true;
            worksView.LoadUrl("https://roadworks.org/");
        }
    }
}
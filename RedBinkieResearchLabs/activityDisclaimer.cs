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
    [Activity(Theme = "@android:style/Theme.NoTitleBar")]
    public class activityDisclaimer : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.layoutDisclaimer);

            //build the menu
            clsMenu menu = new clsMenu(this);
            menu.buildMenuIndividual(10);
            menu.buildMenu();
        }
    }
}
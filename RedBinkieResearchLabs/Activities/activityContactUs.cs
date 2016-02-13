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
    public class activityContactUs : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.layoutContactUs);

            //build the menu
            clsMenu menu = new clsMenu(this);
            menu.buildMenuIndividual(8);
            menu.buildMenu();

            //build the links
            buildLinks();

        }

        void buildLinks()
        {
            //attach actions to the links
            TableRow lnkFacebook = FindViewById<TableRow>(Resource.Id.tableRow21);
            lnkFacebook.Click += delegate {
                var uriFacebook = Android.Net.Uri.Parse("https://www.facebook.com/wessexwater");
                var intenFacebook = new Intent(Intent.ActionView, uriFacebook);
                StartActivity(intenFacebook);
            };

            TableRow lnkTwitter = FindViewById<TableRow>(Resource.Id.tableRow22);
            lnkTwitter.Click += delegate {
                var uriTwitter = Android.Net.Uri.Parse("http://www.twitter.com/wessexwater");
                var intenTwitter = new Intent(Intent.ActionView, uriTwitter);
                StartActivity(intenTwitter);
            };

            TableRow lnkYoutube = FindViewById<TableRow>(Resource.Id.tableRow25);
            lnkYoutube.Click += delegate {
                var uriYoutube = Android.Net.Uri.Parse("http://www.youtube.com/user/wessexwaterwebmaster");
                var intenYoutube = new Intent(Intent.ActionView, uriYoutube);
                StartActivity(intenYoutube);
            };

            //launch the phone dialer for the support
            TableRow lnkBills = FindViewById<TableRow>(Resource.Id.tableRow23);
            lnkBills.Click += delegate {
                var uriBills = Android.Net.Uri.Parse("tel:0345 600 3 600");
                var intenBills = new Intent(Intent.ActionView, uriBills);
                StartActivity(intenBills);
            };

            TableRow lnkSupply = FindViewById<TableRow>(Resource.Id.tableRow24);
            lnkSupply.Click += delegate {
                var uriSupply = Android.Net.Uri.Parse("tel:0345 600 4 600");
                var intenSupply = new Intent(Intent.ActionView, uriSupply);
                StartActivity(intenSupply);
            };
        }
    }
}
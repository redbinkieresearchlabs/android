
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
using Newtonsoft.Json;
using Android.Text;

namespace RedBinkieResearchLabs
{
    [Activity(Label = "Fault details")]
    public class activityFaultDetail : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ContentLayoutFaultDetail);

            //Show back butotn on actionbar,
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            //Retrieve data bundle passed from ListActivity
            Post item = JsonConvert.DeserializeObject<Post>(Intent.GetStringExtra("item"));

            FindViewById<TextView>(Resource.Id.FeedTitle).Text = "Title: "+Html.FromHtml(item.title).ToString();
            FindViewById<TextView>(Resource.Id.FeedType).Text = "Type: " + Html.FromHtml(item.type).ToString();
            FindViewById<TextView>(Resource.Id.FeedDate).Text = "Date Logged: "+Html.FromHtml(item.date).ToString();
            FindViewById<TextView>(Resource.Id.FeedStatus).Text = "Status: " + Html.FromHtml(item.status).ToString();
            FindViewById<TextView>(Resource.Id.FeedContent).Text = "Details: "+Html.FromHtml(item.details).ToString();

            ImageView imageView = FindViewById<ImageView>(Resource.Id.FeaturedImg);

            //Download and display image
            Koush.UrlImageViewHelper.SetUrlDrawable(imageView, Html.FromHtml(item.thumbnail).ToString(), Resource.Drawable.Placeholder);
        }

        //Handling home button click event
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    break;
            }
            return true;
        }
    }
}
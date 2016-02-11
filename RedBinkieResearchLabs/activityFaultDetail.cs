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
    public class activityFaultDetail : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layoutFaultDetail);

            //build the menu
            clsMenu menu = new clsMenu(this);
            menu.buildMenuIndividual(5);
            menu.buildMenu();

            string text = Intent.GetStringExtra("FaultID") ?? "No Fault ID Found";

            TextView txtDisplay = FindViewById<TextView>(Resource.Id.textViewParse);
            txtDisplay.Text = text;

            ImageView image = FindViewById<ImageView>(Resource.Id.imageViewUploadedImage);
            image.Click += delegate
            {
                var imageIntent = new Intent();
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);
            };

        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if(resultCode == Result.Ok)
            {
                var imageView = FindViewById<ImageView>(Resource.Id.imageViewUploadedImage);
                imageView.SetImageURI(data.Data);
            }
        }
    }
}
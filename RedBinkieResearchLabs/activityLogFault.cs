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
    public class activityLogFault : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.layoutFault);

            //build the menu
            clsMenu menu = new clsMenu(this);
            menu.buildMenuIndividual(5);
            menu.buildMenu();

            //load our fault status filter
            Spinner spinnerFaultStatus = FindViewById<Spinner>(Resource.Id.filterFaultStatus);

            spinnerFaultStatus.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.faultFilterArray, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerFaultStatus.Adapter = adapter;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner filter = (Spinner)sender;
            string strFilterSelected = string.Format("{0}", filter.GetItemAtPosition(e.Position));
            loadItems(strFilterSelected);
        }

        void loadItems(string filter)
        {
            string[] listItems = new string[] { "Leaking Meter", "Burst Pipe", "Faulty Meter", "Dirty Water" };
            //ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem2, listItems);
        }
    }
}
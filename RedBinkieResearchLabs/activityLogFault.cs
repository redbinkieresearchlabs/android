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

            //load our header for the list
            ListView listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.ItemClick += new EventHandler<AdapterView.ItemClickEventArgs>(fault_ItemSelected);
        }
        private void fault_ItemSelected(object sender, AdapterView.ItemClickEventArgs e)
        {
            ListView lv = (ListView)sender;
           string val=lv.GetItemAtPosition(e.Position).ToString();
            
            //string strFilterSelected = string.Format("{0}", lv.GetItemAtPosition(e.Position));
            var activityDetail = new Intent(this, typeof(activityFaultDetail));
            activityDetail.PutExtra("FaultID", string.Format("{0}", val));

            StartActivity(activityDetail);
        }

            void loadItems(string filter)
        {
            string[,] listItems = new string[,] { { "Leaking Meter" ,"Resolved"}, { "Burst Pipe", "Open"}, { "Faulty Meter", "Resolved"}, { "Dirty Water", "Closed"}, { "Dirty Water 1", "Closed" }, { "Dirty Water 2", "Closed" } };

            //build dynamic table rows and cells
            var data = new List<listviewModelFault>{};
            int intNo = 1;
            for (int i = 0;i< listItems.Length / 2;i++)
            {
                if(filter == listItems[i, 1] || filter=="All")
                { 
                    data.Add(new listviewModelFault
                    {
                        colNo = intNo,
                        colFault = listItems[i,0],
                        colStatus = listItems[i, 1]
                    });
                    intNo++;
                }
            }
            
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = new clsListViewAdapter(this, data);
        }
    }
}
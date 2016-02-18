using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

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
        RootObject result;
        ListView listView;
        ProgressBar progress;
        string url = "http://www.redbinkie.com/sampleData.txt";

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

            //add a listener to our add button
            //var AddFault = FindViewById(Resource.Id.btnAddFault);
            //AddFault.Click += (sender, e) => {
            //    StartActivity(typeof(actFaultEdit));
            //};
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner filter = (Spinner)sender;
            string strFilterSelected = string.Format("{0}", filter.GetItemAtPosition(e.Position));
            //loadItems(strFilterSelected);

            //load our header for the list
           listView = FindViewById<ListView>(Resource.Id.listView1);
        
            //Initializing listview
            listView.ItemClick += OnListItemClick;
            progress = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            //Showing loading progressbar
            progress.Visibility = ViewStates.Visible;

            //listView.Adapter = new CusotmListAdapter(this, listData);
            //Download and display data in url
            downloadJsonFeedAsync(url);
        }

        public async void downloadJsonFeedAsync(String url)
        {
            var httpClient = new HttpClient();
            Task<string> contentsTask = httpClient.GetStringAsync(url);

            // await! control returns to the caller and the task continues to run on another thread
            string content = await contentsTask;
            //Convert string to JSON object
            result = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(content);

            //Update listview
            RunOnUiThread(() => {
                listView.Adapter = new CusotmListAdapter(this, result.faults);
                progress.Visibility = ViewStates.Gone;
            });
        }

        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Post item = result.faults.ElementAt(e.Position);
            // Do whatever you like here
            Intent i = new Intent(Application.Context, typeof(activityFaultDetail));
            i.PutExtra("item", JsonConvert.SerializeObject(item));

            StartActivity(i);
        }

        /*private void fault_ItemSelected(object sender, AdapterView.ItemClickEventArgs e)
        {
            ListView lv = (ListView)sender;
           string val=lv.GetItemAtPosition(e.Position).ToString();
            
            //string strFilterSelected = string.Format("{0}", lv.GetItemAtPosition(e.Position));
            var activityDetail = new Intent(this, typeof(activityFaultDetail));
            activityDetail.PutExtra("FaultID", string.Format("{0}", val));

            StartActivity(activityDetail);
        }*/
    }
}
using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using Android.Media;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Android.Graphics;

namespace RedBinkieResearchLabs
{
    public class CusotmListAdapter : BaseAdapter<Post>
    {
        Activity context;
        List<Post> list;

        public CusotmListAdapter(Activity _context, List<Post> _list)
            : base()
        {
            this.context = _context;
            this.list = _list;
        }

        public override int Count
        {
            get { return list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Post this[int index]
        {
            get { return list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            // re-use an existing view, if one is available
            // otherwise create a new one
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.FaultListLayout, parent, false);

            Post item = this[position];
            view.FindViewById<TextView>(Resource.Id.Title).Text = item.title;
            view.FindViewById<TextView>(Resource.Id.Description).Text = "Status: " + item.status;
            view.FindViewById<TextView>(Resource.Id.Status).Text = "Report ID: " + item.id;


            using (var imageView = view.FindViewById<ImageView>(Resource.Id.Thumbnail))
            {
                string url = Android.Text.Html.FromHtml(item.thumbnail).ToString();

                //Download and display image
                Koush.UrlImageViewHelper.SetUrlDrawable(imageView,
                    url, Resource.Drawable.Placeholder);
            }

            //lets try alternate colors
            if(position % 2 == 0 )//even row
            {
                view.FindViewById<RelativeLayout>(Resource.Id.relativeLayout1).SetBackgroundColor(Color.ParseColor("#58FAF4"));
            }

            return view;
        }
    }

    public class RootObject
    {
        //public string status { get; set; }
        //public int count { get; set; }
        //public int pages { get; set; }
        public List<Post> faults { get; set; }
    }

    public class Post
    {
        public string id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string thumbnail { get; set; }
        public string details { get; set; }
        public string date { get; set; }
    }

}
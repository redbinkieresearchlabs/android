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
    class clsListViewAdapter : BaseAdapter<listviewModelFault>
    {
        private readonly IList<listviewModelFault> _items;
        private readonly Context _context;

        public clsListViewAdapter(Context context, IList<listviewModelFault> items)
        {
            _items = items;
            _context = context;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];
            var view = convertView;

            if (view == null)
            {
                var inflater = LayoutInflater.FromContext(_context);
                view = inflater.Inflate(Resource.Layout.listFaultTemplate, parent, false);
            }

            view.FindViewById<TextView>(Resource.Id.FirstText).Text = item.colNo.ToString();
            view.FindViewById<TextView>(Resource.Id.SecondText).Text = item.colFault;
            view.FindViewById<TextView>(Resource.Id.ThirdText).Text = item.colStatus;

            return view;
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override listviewModelFault this[int position]
        {
            get { return _items[position]; }
        }

        
    }
}
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
using Java.Lang;

namespace TestAndroid.SqliteDB
{
    class AdapterListview : BaseAdapter
    {
        Activity context;
        List<string> users;

        public AdapterListview(Activity context, List<string> users)
        {
            this.context = context;
            this.users = users;
        }

        public override int Count
        {
            get
            {
                return users.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null) {
                view = context.LayoutInflater.Inflate(Resource.Layout.seriesListviewitem, null);
            }
            view.FindViewById<TextView>(Resource.Id.text_description).Text = users[position];

            return view;

        }
    }
}
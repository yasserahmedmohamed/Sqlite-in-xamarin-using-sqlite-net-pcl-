using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using System.Collections.Generic;
using AndroidProjectFirst.Classes;
using AndroidProjectFirst.Classes.SqliteDB;
using TestAndroid.SqliteDB;

namespace TestAndroid
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{

        ListView list_series;
        EditText depart_edittext;
        Button but_get_all, but_update, but_delete, but_add_new;
        List<string> user_names = new List<string>();
        SqlDB sq;


        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

            depart_edittext = FindViewById<EditText>(Resource.Id.depart_edittext);
            but_get_all = FindViewById<Button>(Resource.Id.but_get_all);
            but_update = FindViewById<Button>(Resource.Id.but_update);
            but_delete = FindViewById<Button>(Resource.Id.but_delete);
            but_add_new = FindViewById<Button>(Resource.Id.but_add_new);
            but_add_new.Clickable = true;

            but_get_all.Click += delegate {
                Toast.MakeText(this, "done", ToastLength.Short).Show();
                List<string> Alldepartmnets = new List<string>();
                Alldepartmnets = sq.getAlldeparts();
                list_series.Adapter = new AdapterListview(this, Alldepartmnets);
            };
            but_update.Click += But_update_Click;
            but_delete.Click += But_delete_Click;
            but_add_new.Click += But_add_new_Click;
            //setritfit();

            list_series = FindViewById<ListView>(Resource.Id.list_series);
            //tableItems = new List<UsersTest>();

            sq = new SqlDB();


            list_series.ItemClick += List_series_ItemClick;



        }

        private void but_add_newclic(object sender, EventArgs e)
        {
            Toast.MakeText(this, "toast test", ToastLength.Long).Show();
        }
        private void But_add_new_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "done", ToastLength.Short).Show();
            sq.insert(depart_edittext.Text.ToString());
        }

        private void But_delete_Click(object sender, EventArgs e)
        {

            sq.delete(Convert.ToInt32(depart_edittext.Text.ToString()));
        }

        private void But_update_Click(object sender, EventArgs e)
        {
            Departments d = new Departments();
            string[] parts = depart_edittext.Text.ToString().Split('-');
            d.Id = Convert.ToInt32(parts[0]);
            d.FullName = parts[1];
            sq.update(d);
        }

        private void But_get_all_Click(object sender, EventArgs e)
        {
            List<string> Alldepartmnets = new List<string>();
            Alldepartmnets = sq.getAlldeparts();
            list_series.Adapter = new AdapterListview(this, Alldepartmnets);


        }

        private void List_series_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //list_series.Visibility = Android.Views.ViewStates.Gone;

        }


    }



}


using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace CustomRowView {
    [Activity(Label = "RentStop",  Icon = "@drawable/icon")]
    public class HomeScreen : Activity{//, View.IOnClickListener {

        List<TableItem> tableItems = new List<TableItem>();
        ListView listView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.HomeScreen);
            listView = FindViewById<ListView>(Resource.Id.List);

            tableItems.Add(new TableItem() { Heading = "books", SubHeading = "65 items", ImageResourceId = Resource.Drawable.books });
            tableItems.Add(new TableItem() { Heading = "laptops", SubHeading = "17 items", ImageResourceId = Resource.Drawable.laptop });
            tableItems.Add(new TableItem() { Heading = "computers", SubHeading = "5 items", ImageResourceId = Resource.Drawable.pc });
            tableItems.Add(new TableItem() { Heading = "cars", SubHeading = "5 items", ImageResourceId = Resource.Drawable.lambo});
            listView.Adapter = new HomeScreenAdapter(this, tableItems);

            listView.ItemClick += OnListItemClick;
        }

        protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
          
            var detailview = new Intent(this, typeof(detailview));
            var listView = sender as ListView;
            var t = tableItems[e.Position];
            Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();
            Console.WriteLine("Clicked on " + t.Heading);
            StartActivity(detailview);
        }
    }
}

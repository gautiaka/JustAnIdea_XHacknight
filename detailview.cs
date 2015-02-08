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

namespace CustomRowView
{
    [Activity(Label = "Activity2")]
    public class detailview : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.layout2);

            ImageView image = FindViewById<ImageView>(Resource.Id.imageView1);
            image.SetImageResource(Resource.Drawable.laptop);

            // Create your application here
        }
    }
}
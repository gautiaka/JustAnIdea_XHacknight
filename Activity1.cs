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
using Android.Locations;
using Microsoft.WindowsAzure.MobileServices;

namespace CustomRowView
{
    [Activity(Label = "Activity1",MainLauncher = true)]
    public class Activity1 : Activity
    {
       
         protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);

            CurrentPlatform.Init();

            SetContentView(Resource.Layout.layout1);
            ImageView image1 = FindViewById<ImageView>(Resource.Id.banner);
            image1.SetImageResource(Resource.Drawable.clouds);
            var user = FindViewById<EditText>(Resource.Id.uname);
            var pass = FindViewById<EditText>(Resource.Id.upass);

            

            Button loginbutton = FindViewById<Button>(Resource.Id.login);
            loginbutton.Click += (sender, e) =>
            {
               
                if (user.Text == "Goutam" && pass.Text == "123")
                {
                    var intent = new Intent(this, typeof(HomeScreen));

                    StartActivity(intent);
                } 
                else
                {
                    Toast.MakeText(this, "Wrong Input", ToastLength.Long).Show();
                }
            };
            Button newadbutton = FindViewById<Button>(Resource.Id.newad);
            newadbutton.Click += (sender, e) =>
            {

                
                    var ad = new Intent(this, typeof(Activity2));

                    StartActivity(ad);
                
                
                    Toast.MakeText(this, "There You Go!", ToastLength.Long).Show();
                
            };
        }

         }
}
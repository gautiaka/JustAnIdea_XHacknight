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
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;
using AndroidHUD;

namespace CustomRowView
{
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity
    {

        public static MobileServiceClient MobileService = new MobileServiceClient(
                                                    "https://justanidea.azure-mobile.net/",
                                                    "pqFHSNEYNKvaRurRqEDMbCFJvrnAaw86"
                                                );

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.layout3);
            // ImageView image2 = FindViewById<ImageView>(Resource.Id.imageButton1);
            // image2.SetImageResource(Resource.Drawable.clouds);
            // Create your application here
            Button submitbutton = FindViewById<Button>(Resource.Id.submitad);
            var adText = FindViewById<EditText>(Resource.Id.adText);

            submitbutton.Click += async (sender, e) =>
            {
                AndHUD.Shared.Show(this, "Loading..", -1, MaskType.Clear, null, null, true, null);

                var intent = new Intent(this, typeof(Activity1));

                await MobileService.GetTable<RentStop>().InsertAsync(new RentStop
                {
                    RentItem = adText.Text
                });
                AndHUD.Shared.Dismiss(this);
                StartActivity(intent);


                Toast.MakeText(this, "Your Ad has been Submitted", ToastLength.Long).Show();

            };
        }
    }

    public class RentStop
    {
        public string Id { get; set; }
        [JsonProperty("rentitem")]
        public string RentItem { get; set; }
    }
}




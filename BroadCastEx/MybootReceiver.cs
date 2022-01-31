using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BroadCastEx
{
    [BroadcastReceiver(Enabled =true)]
    [IntentFilter(new[] { "com.xamarin.example.Test" })]
    public class MybootReceiver : BroadcastReceiver
    {
        
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "value recieved:" + intent.GetStringExtra("key"), ToastLength.Short).Show();
        }
    }
}
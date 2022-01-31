using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace BroadCastEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button mybutton;
        MybootReceiver receiver;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            mybutton = FindViewById<Button>(Resource.Id.button1);
            receiver = new MybootReceiver();
            mybutton.Click += Mybutton_Click;
        }

        private void Mybutton_Click(object sender, System.EventArgs e)
        {
            Intent message = new Intent("com.xamarin.example.Test");
            message.PutExtra("key", "Testing Broadcast");
            SendBroadcast(message);
        }

        protected override void OnResume()
        {
            base.OnResume();
            RegisterReceiver(receiver, new IntentFilter("com.xamarin.example.Test"));
        }
        protected override void OnPause()
        {
            UnregisterReceiver(receiver);
            base.OnPause();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
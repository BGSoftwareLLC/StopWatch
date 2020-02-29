using System.Threading;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace BGStopwatch.Droid
{
    [Activity(Label = "BGStopwatch", Icon = "@drawable/icon", Theme = "@style/Theme.Splash", MainLauncher = true,
        NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        /// <summary>
        ///     called on creation of the splash screen activity
        /// </summary>
        /// <param name="bundle">Android mapping from string value to parcable type</param>
        protected override void OnCreate(Bundle bundle)
        {
            // initialize Analytics and crash reporting from Azure Mobile Center.  
            //MobileCenter.Start(typeof(Analytics), typeof(Crashes));
            //Analytics.TrackEvent("Application Analytics Initiated.");

            // get the display layout for this splash activity... 
            // and queue a thread to sleep it until the main activity is relevant.  
            SetContentView(Resource.Layout.SplashLayout);
            ThreadPool.QueueUserWorkItem(o => LoadActivity());

            base.OnCreate(bundle);
        }

        /// <summary>
        ///     loading the splash activity, set to run for 2500 ms
        /// </summary>
        private void LoadActivity()
        {
            // sleep this activity / display the splash screen until 
            // main activity is relevant and the app needs to go to work.  
            Thread.Sleep(2500); // Simulate a long pause    
            RunOnUiThread(()
                => StartActivity(typeof(MainActivity)));
        }

        /// <summary>
        ///     eat the back button pressed event... this is the splash activity
        /// </summary>
        public override void OnBackPressed()
        {
        }
    }
}
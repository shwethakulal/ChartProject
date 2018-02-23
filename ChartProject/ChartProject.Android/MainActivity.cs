using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DeviceOrientation.Forms.Plugin.Droid;

namespace ChartProject.Droid
{
    [Activity(Label = "ChartProject", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation), ]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
           // DeviceOrientationImplementation.Init();
            LoadApplication(new App());
        }
       
        //public override void OnConfigurationChanged(global::Android.Content.Res.Configuration newConfig)
        //{
        //    base.OnConfigurationChanged(newConfig);
        //    DeviceOrientationImplementation.NotifyOrientationChange(newConfig);
        //}
    }
}


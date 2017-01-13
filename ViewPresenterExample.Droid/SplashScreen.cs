using Android.App;
using Android.Widget;
using Android.OS;
using MvvmCross.Droid.Views;

namespace ViewPresenterExample.Droid
{
    [Activity(Label = "ViewPresenterExample.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.activity_splash_screen)
        {

        }
    }
}


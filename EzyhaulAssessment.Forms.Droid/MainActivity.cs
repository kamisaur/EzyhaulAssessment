using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using MvvmCross.Forms.Platforms.Android.Views;
using EzyhaulAssessment.Forms.UI;
using MvvmCross.Forms.Platforms.Android.Core;
using EzyhaulAssessment.Core;
using Android.Content.PM;

namespace EzyhaulAssessment.Forms.Droid
{
		//Icon = "@drawable/icon",

    [Activity(
		Label = "TipCalc.Forms.Droid",
		Theme = "@style/MyTheme",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
		LaunchMode = LaunchMode.SingleTask)]
	public class MainActivity : MvxFormsAppCompatActivity<MvxFormsAndroidSetup<App, FormsApp>, App, FormsApp>
	{
        protected override void OnCreate(Bundle savedInstanceState)
        {
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			// Set our view from the "main" layout resource
			//SetContentView(Resource.Layout.activity_main);

		}
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
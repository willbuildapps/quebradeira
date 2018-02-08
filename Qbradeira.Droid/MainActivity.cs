using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Distribute;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using System;

namespace Qbradeira.Droid
{
	[Activity(Label = "Qbradeira", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			AppCenter.Start("67a93127-8cae-4fdc-a350-7333fc6dcdcd"
							, typeof(Analytics)
							, typeof(Crashes)
						   //, typeof(Distribute)
						   );

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			var doSomethingButton = FindViewById<Button>(Resource.Id.do_something_button);
			var killMeButton = FindViewById<Button>(Resource.Id.killme_button);

			doSomethingButton.Click += DoSomethingButton_Click;
			killMeButton.Click += KillMeButton_Click;
		}

		void DoSomethingButton_Click(object sender, System.EventArgs e)
		{
			Toast.MakeText(this, "Vamos fingir que algo importante está acontecendo agora!",
						   ToastLength.Long).Show();

			Analytics.TrackEvent("Algo importante aconteceu!");
		}

		void KillMeButton_Click(object sender, System.EventArgs e)
		{
			Analytics.TrackEvent("A maldade prevalece!");

			throw new StackOverflowException("Você acabou de matar um app incrível!");
		}
	}
}


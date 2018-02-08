using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace Qbradeira.Droid.UITests
{
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			app = ConfigureApp.Android.StartApp();
		}

		[Test]
		public void ClickingDoSomethingButtonShouldShowA()
		{
			Func<AppQuery, AppQuery> doSomethingButton = c => c.Button("do_something_button");

			app.Tap(doSomethingButton);

			AppResult[] results = app.Query(doSomethingButton);

			app.Screenshot("Do Something Button clicked!");
			app.WaitForElement("Vamos fingir que algo importante está acontecendo agora!");
			app.Screenshot("Something going on!");
			app.WaitForNoElement("Vamos fingir que algo importante está acontecendo agora!");
			app.Screenshot("Something happened!");
		}
	}
}

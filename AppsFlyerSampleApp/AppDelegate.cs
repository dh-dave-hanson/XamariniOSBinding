﻿using Foundation;
using UIKit;
using AppsFlyerXamarinBinding;

namespace AppsFlyerSampleApp
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.

	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		AppsFlyerXamarinBinding.AppsFlyerTracker tracker = AppsFlyerXamarinBinding.AppsFlyerTracker.SharedTracker();
		AppsFlyerTrackerDelegate af_delegate = new AppsFlyerConversionDataDelegate();

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method
			tracker.IsDebug = true;
			tracker.AppsFlyerDevKey = "rbz2mfgZQY5mSEYNTyjwni";
			tracker.AppleAppID = "989898989";

			AppsFlyerTracker.SharedTracker ().LoadConversionDataWithDelegate (af_delegate);

			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
			tracker.TrackAppLaunch ();

		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}

		//Universal Links
		public override bool ContinueUserActivity (UIApplication application, 
			NSUserActivity userActivity, 
			UIApplicationRestorationHandler completionHandler)
		{
			AppsFlyerTracker.SharedTracker ().ContinueUserActivity (userActivity, completionHandler);
			return true;
		}
	}
}



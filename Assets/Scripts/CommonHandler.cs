using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using GoogleMobileAds;
//using GoogleMobileAds.Api;
using System;
//
public class CommonHandler : MonoBehaviour {
//	public static CommonHandler instance = null;
//	public GoogleAnalyticsV4 googleAnalytics;
//
//	public static InterstitialAd interstitial;
//	public static BannerView bannerView;
//	public static bool adsBrought;
//
//	static string adUnitId = "ca-app-pub-1476835797428796/9384239869";
//	public static string testDeviceID = "3C53F0EC3D39EB46";
//
//	void Awake() {
//		instance = this;
//	}
//
//	void Start() {
//
//		Screen.sleepTimeout = SleepTimeout.NeverSleep;
//
//		if(PlayerPrefs.GetInt("AdsBrought") == 1)
//			adsBrought = true;
//
//		//GoogleAnalyticsScreen("Home");
//		//RequestInterstitial();
//
//		//Debug.Log(""+Screen.width+Screen.height);
//	}
//
//	void Update() {
//		if(interstitial == null)
//			return;
//		else {
//			ShowInterstitial();
//			interstitial = null;
//		}
//	}
//
////	void OnGUI() {
////		if(interstitial != null)
////			GUILayout.Button(interstitial.IsLoaded().ToString());
////		GUILayout.Button(UnityEngine.Advertisements.Advertisement.IsReady().ToString());
////	}
//
//	public void GoogleAnalyticsEvent(string cat, string act) {
//		googleAnalytics.LogEvent(new EventHitBuilder()
//			.SetEventCategory(cat)
//			.SetEventAction(act));
//	}
//
//	public void GoogleAnalyticsScreen(string scr) {
//		googleAnalytics.LogScreen(scr);
//	}
//
//	private static AdRequest createAdRequest()
//	{
//		//return new AdRequest.Builder().Build();
//
//		return new AdRequest.Builder()
//			.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
//			.AddTestDevice(testDeviceID)  // My test device.
//			.Build();
//	}
//
//	public static void RequestInterstitial()
//	{ 
//		if(!adsBrought) {
//			if (interstitial == null) 
//			{
//
//				interstitial = new InterstitialAd(adUnitId);
//
//				interstitial.LoadAd(createAdRequest());
//
//			} 
//			else 
//			{
//				print ("RequestInterstitial() ignored because interstitial ad is already requested");
//			}
//		} else {
//			if(interstitial != null)
//				interstitial.Destroy();
//		}
//	}
//
//	public static void ShowInterstitial()
//	{
//		if(!adsBrought) {
//			if(interstitial != null)
//			{
//				if (interstitial.IsLoaded())
//				{
//					interstitial.Show();
//					interstitial = null;
//					RequestInterstitial();
//				}
//				else
//				{
//					print("Interstitial is not ready yet.");
//					//status = "Not Ready";
//				}
//			}
//			else 
//			{
//				print ("ShowInterstitial() ignored because interstitial ad is not requested");
//			}
//		}else {
//			if(interstitial != null)
//				interstitial.Destroy();
//		}
//	}
}

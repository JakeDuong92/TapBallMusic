using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    private InterstitialAd interstitial;
    // Start is called before the first frame update
    void Start()
    {
        //RequestInterstitial();
    }
    public void RequestInterstitials(string interID_Android,string interID_IOS)
    {
#if UNITY_ANDROID
        string adUnitId = interID_Android;
#elif UNITY_IPHONE
        string adUnitId = interID_IOS;
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += Interstitial_OnAdLoaded;
        this.interstitial.LoadAd(request);
    }

    private void Interstitial_OnAdLoaded(object sender, System.EventArgs e)
    {
        interstitial.Show();
    }
}

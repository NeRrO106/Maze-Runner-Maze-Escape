using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class Ads : MonoBehaviour{
    string gameId = "ca-app-pub-8209392673593580~6374170261";
    string adinterid = "ca-app-pub-8209392673593580/4943321486";
    private InterstitialAd interstitialAd;
    
    
    [System.Obsolete]
    void Start(){
        MobileAds.Initialize(gameId);
        RequestInterstitial();
    }
    void RequestInterstitial(){
        interstitialAd = new InterstitialAd(adinterid);
        interstitialAd.LoadAd(new AdRequest.Builder().Build());
    }

    public void ShowInterstitialAd(){
        if (this.interstitialAd.IsLoaded()) {
            this.interstitialAd.Show();
        }
    }
}
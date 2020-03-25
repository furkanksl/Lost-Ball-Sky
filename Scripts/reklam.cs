using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class reklam : MonoBehaviour
{

    public InterstitialAd interstitial;
    static reklam reklamKontrol;

    public void Start()
    {
        
        if (reklamKontrol == null)
        {
            DontDestroyOnLoad(gameObject);
            reklamKontrol = this;

            /// 1. aşamaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                #if UNITY_ANDROID
                            string appId = "ca-app-pub-4057881438378682~5730025638";
                #elif UNITY_IPHONE
                                        string appId = "ca-app-pub-3940256099942544~1458002511";
                #else
                                        string appId = "unexpected_platform";
                #endif

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(appId);

            /// 2. aşamaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            #if UNITY_ANDROID

            string adUnitId = "ca-app-pub-4057881438378682/7655257494";
            #elif UNITY_IPHONE
                                    string adUnitId = "ca-app-pub-3940256099942544/4411468910";
            #else
                                    string adUnitId = "unexpected_platform";
            #endif


            interstitial = new InterstitialAd(adUnitId);

            /// 3. aşamaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            /// 

            AdRequest request = new AdRequest.Builder()/*.AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")*/.Build();

            interstitial.LoadAd(request);

            /// 4. aşamaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

        }
        else
        {

            Destroy(gameObject);
        }




    }


    public void reklamiGoster()
    {
        if (this.interstitial.IsLoaded())
       {
            this.interstitial.Show();
            Debug.Log("REKLAM");
        }
        reklamKontrol = null;
        Destroy(gameObject);
    }
}

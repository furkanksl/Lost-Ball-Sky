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

                #if UNITY_ANDROID
                            string appId = "--------------------";
                #elif UNITY_IPHONE
                                        string appId = "--------------";
                #else
                                        string appId = "unexpected_platform";
                #endif

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(appId);

            #if UNITY_ANDROID

            string adUnitId = "-----------------";
            #elif UNITY_IPHONE
                                    string adUnitId = "--------------";
            #else
                                    string adUnitId = "unexpected_platform";
            #endif


            interstitial = new InterstitialAd(adUnitId);

           
            AdRequest request = new AdRequest.Builder()/*.AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")*/.Build();

            interstitial.LoadAd(request);

            
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

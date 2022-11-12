using System;

using System.Collections;

using System.Collections.Generic;

using GoogleMobileAds.Api;

using UnityEngine;



public class LoadAds : MonoBehaviour

{



    private InterstitialAd interstitial_Ad;

    private RewardedAd rewardedAd;



    public string interstitial_Ad_ID;

    public string rewardedAd_ID;

    public static LoadAds instance;



    private void Awake()

    {

        DontDestroyOnLoad(gameObject);

        if (instance == null)

        {

            instance = this;

        }

        else if (instance != null)

        {

            Destroy(gameObject);

        }

    }

    void Start()

    {

        interstitial_Ad_ID = "ca-app-pub-2355447785084998/2578998086";

        rewardedAd_ID = "ca-app-pub-2355447785084998/1479155860";



        MobileAds.Initialize(initStatus => { });



        RequestInterstitial();

        RequestRewardedVideo();



    }



    private void RequestInterstitial()

    {

        interstitial_Ad = new InterstitialAd(interstitial_Ad_ID);

        interstitial_Ad.OnAdLoaded += HandleOnAdLoaded;

        AdRequest request = new AdRequest.Builder().Build();

        interstitial_Ad.LoadAd(request);

    }



    private void RequestRewardedVideo()

    {

        rewardedAd = new RewardedAd(rewardedAd_ID);

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;

        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;

        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);

    }



    public void ShowInterstitial()

    {

        if (interstitial_Ad.IsLoaded())

        {

            interstitial_Ad.Show();

            RequestInterstitial();

        }
    }



    public void ShowRewardedVideo()

    {

        if (rewardedAd.IsLoaded())

        {

            rewardedAd.Show();

        }

    }



    public void HandleOnAdLoaded(object sender, EventArgs args)

    {



    }



    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)

    {

        RequestRewardedVideo();

    }



    public void HandleRewardedAdClosed(object sender, EventArgs args)

    {

        RequestRewardedVideo();

    }



    public void HandleUserEarnedReward(object sender, Reward args)

    {

        RequestRewardedVideo();

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 10);

       



    }

}
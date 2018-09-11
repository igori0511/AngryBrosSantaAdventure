using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System.Threading;

public class AdsController : MonoBehaviour {

    private BannerView bannerView;
    private InterstitialAd interstitial;

    public static AdsController instance;

    void Awake() {
        MakeSingleton();
    }

	void Start () {
        RequestBanner();
        RequestInterstitial();
    }

    void MakeSingleton() {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Scene applicationLevelScene = SceneManager.GetActiveScene();
        string sceneName = applicationLevelScene.name;
        MonoBehaviour.print(sceneName);
        MonoBehaviour.print(sceneName != "Gameplay" && this.bannerView != null);
        

        if (sceneName != "Gameplay" && this.bannerView != null) {
            HideBanner();
            MonoBehaviour.print("In hide");
        }
        if (sceneName != "MainMenu" && interstitial != null)
        {
            ShowInterstitial();
        }
    }


    private void RequestBanner()
    {
        // These ad units are configured to always serve test ads.
        #if UNITY_EDITOR
          string adUnitId = "unused";
        #elif UNITY_ANDROID
          string adUnitId = "ca-app-pub-8894473549560373/8791989249";
        #elif UNITY_IPHONE
          string adUnitId = "unused";
        #else
          string adUnitId = "unexpected_platform";
        #endif
        
        MonoBehaviour.print(adUnitId);
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Register for ad events.
        this.bannerView.OnAdLoaded += this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleAdOpened;
        this.bannerView.OnAdClosed += this.HandleAdClosed;
        this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;

        // Load a banner ad.
        this.bannerView.LoadAd(this.CreateAdRequest());

        this.bannerView.Hide();
    }

    private void RequestInterstitial()
    {
        // These ad units are configured to always serve test ads.
        #if UNITY_EDITOR
           string adUnitId = "unused";
        #elif UNITY_ANDROID
           string adUnitId = "ca-app-pub-8894473549560373/2745455644";
        #elif UNITY_IPHONE
           string adUnitId = "unused";
        #else
           string adUnitId = "unexpected_platform";
        #endif
        
        MonoBehaviour.print(adUnitId);
        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        RegisterDeligateForInterstitialBanner();
        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    // Returns an ad request with custom ad targeting.
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            /*.AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice("AEC123B35A8452CD")
            .AddTestDevice("2277C480621AF12B")
            .AddTestDevice("6D3C075389072FD2")*/
            .Build();
    }

    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            RequestInterstitial();
        }
    }


    public void ShowBanner()
    {
        bannerView.Show();
    }

    public void HideBanner() {
        bannerView.Hide();
    }

    public void RegisterDeligateForBanner() {
        // Register for ad events.
        this.bannerView.OnAdLoaded += this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleAdOpened;
        this.bannerView.OnAdClosed += this.HandleAdClosed;
        this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;

    }

    public void RegisterDeligateForInterstitialBanner()
    {
        // Register for ad events.
        this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
        this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
        this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
        this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
        this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;
    }

    //--------------------

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received with message: " + args.ToString());
        //this.bannerView.Show();
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleAdFailedToLoad event received with message: " + args.Message);
       // Thread.Sleep(7000);
       // RequestBanner();
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received with message: " + args.ToString());
        //Thread.Sleep(7000);
       // RequestBanner();
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
    }

    //-----
    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //interstitial.Destroy();
       // RequestInterstitial();
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
       // interstitial.Destroy();
      //  RequestInterstitial();
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
    }

}

public class GoogleMobileAdsHandler : IDefaultInAppPurchaseProcessor
{
    private readonly string[] validSkus = { "android.test.purchased" };

    // Will only be sent on a success.
    public void ProcessCompletedInAppPurchase(IInAppPurchaseResult result)
    {
        result.FinishPurchase();
       // GoogleMobileAdsDemoScript.OutputMessage = "Purchase Succeeded! Credit user here.";
    }

    // Check SKU against valid SKUs.
    public bool IsValidPurchase(string sku)
    {
        foreach (string validSku in this.validSkus)
        {
            if (sku == validSku)
            {
                return true;
            }
        }

        return false;
    }

    // Return the app's public key.
    public string AndroidPublicKey
    {
        // In a real app, return public key instead of null.
        get { return "pub-8894473549560373"; }
    }
}

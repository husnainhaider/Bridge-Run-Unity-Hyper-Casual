using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameScript : MonoBehaviour
{

    //make a reference to our popup
    [SerializeField] GameObject GDPRPopup;
    [SerializeField] Button interstitialButton;
    [SerializeField] Button rewardedButton;
    [SerializeField] Text CoinText;

    int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        Advertisements.Instance.Initialize();
        
        if(Advertisements.Instance.UserConsentWasSet()==false)
        {
           
        }
        else
        {
         Advertisements.Instance.Initialize();
        }
        

    }
    

    // Update is called once per frame
    void Update()
    {
        if(Advertisements.Instance.IsInterstitialAvailable())
        {
            interstitialButton.interactable = true;
        }
        else
        {
            interstitialButton.interactable = false;
        }
        if(Advertisements.Instance.IsRewardVideoAvailable())
        {
            rewardedButton.interactable = true;
        }
        else
        {
            rewardedButton.interactable = false;
        }
    }

    public void InterstitialButtonPressed()
    {
        Advertisements.Instance.ShowInterstitial();

    }

    public void ShowRewardedVideo()
    {
        Advertisements.Instance.ShowRewardedVideo(VideoComplete);
    }

 private void VideoComplete(bool completed)
     {
        if(completed)
        {
            coins+=1000;
            CoinText.text = "Coins:" + coins;
        }
        else
        {

        }
     }

    public void ShowSmartBanner()
    {
       
        Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM, BannerType.SmartBanner);
    }
    public void ShowBanner()
    {
        Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM, BannerType.Banner);
    }

    public void HideBanner()
    {
        Advertisements.Instance.HideBanner();
    }
}

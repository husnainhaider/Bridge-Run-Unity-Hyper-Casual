using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "General Game Settings")]
//[System.Serializable]
public class GeneralGameSettings : ScriptableObject
{

    [Header("social media accounts")]
    public string moreGamesLink;
    public string instagram_username;
    public string facebook_page_ID;


    [Header("unity ads settings")]
    [Space(30)]
    public string gameId;
    public string InterstitialAdId;
    public string RewardedAdID;
    public string BannerAd_ID;
    public int showInterstitialAfter_n_lose;
    public bool test_Mode = true;


    public AudioClip click_sound;


    [Header("IAP in app purchases")]
    [Space(30)]
    [SerializeField] string IapId_removeAds = "Remove Ads";
    public string removeAds_price;


    [Header("shop list")]
    [Header("cars")]
    [Space(50)]
    public ShopCars[] shopCarsList;

}

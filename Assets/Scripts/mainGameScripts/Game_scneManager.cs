using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_scneManager : MonoBehaviour
{

    public static Game_scneManager instance;

    public GameObject settignsPanle,next, PausePanel, win_panel, losePanel, level_panel, startLevlAnimation, failedBuyIAPpanel;
    // public Button sound_BTN;
    public Sprite mutedImage, non_muted_img;
    public AudioSource AudioSourceUI;
    public GeneralGameSettings generalGameSettings;

    public Text removeAdsPrice_txt;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM, BannerType.Banner);
        Screen.orientation = ScreenOrientation.Portrait;
        removeAdsPrice_txt.text = generalGameSettings.removeAds_price;

        startLevlAnimation.SetActive(true);

        PausePanel.SetActive(false);
        settignsPanle.SetActive(false);
        // removeAdsPanel.SetActive(false);
        losePanel.SetActive(false);
        win_panel.SetActive(false);
        level_panel.SetActive(false);
        failedBuyIAPpanel.SetActive(false);
        

        checkSoundStatus();
         Advertisements.Instance.ShowInterstitial();
        //show banner ads in the when the game start 
        // GameUnityAds.instance.showbannerAD();
        // load interstitia reward video
        // GameUnityAds.instance.loadInterstitialAd();

        // Button.GetComponent<IAO>
    }

    public void checkSoundStatus()
    {
        // check sound status 
        if (PlayerPrefs.GetInt("sound_status", 0) == 0)
        {
            mute_audio();
        }
        else
        {
            inmute_audio();
        }
    }




    private void stopTimeScale()
    {
        Time.timeScale = 0f;
    }

    public void clickOnMoreGames()
    {
        //show more games 
        Application.OpenURL(generalGameSettings.moreGamesLink);
    }

    public void ClickonHomeBtn()
    {
        //Time.timeScale = 1.0f; 
        SceneManager.LoadScene(0);
    }


    public void clickOnSoundBtn()
    {
        int a = PlayerPrefs.GetInt("sound_status", 0);
        if (a == 0)
        {
            //audio muted we need to enable it 
            inmute_audio();
        }
        else
        {
            mute_audio();
        }
    }

    public void mute_audio()
    {
        PlayerPrefs.SetInt("sound_status", 0); //no sound (muted) 
        // sound_BTN.GetComponent<Image>().sprite = mutedImage;
        AudioListener.pause = true;
        //main_Ui_source.mute=main_Ui_source.mute;
        //main_Ui_source.volume=0f;
    }
    public void inmute_audio()
    {
        PlayerPrefs.SetInt("sound_status", 1);  // sound not muted   
        // sound_BTN.GetComponent<Image>().sprite = non_muted_img;
        AudioListener.pause = false;
        // main_Ui_source.mute=!main_Ui_source.mute;
        // main_Ui_source.volume=1.0f;
    }

    public void ConfirmPlayerWantToBuyIap()
    {
        // you buy the item
        Debug.Log("you buy the itme thanks");
        // we should add a value to player pref to check every Time if the user buy the item or not 
        PlayerPrefs.SetInt("isPlayer_BuyNoAds", 1);   // alwayes when i want to show ads check this value if the user buy this or not 
    }

    public void buyingIapRemoveAdsFailed()
    {
        failedBuyIAPpanel.SetActive(true);
        Invoke("inactiveFailedPanel", 2.2f);
    }
    void inactiveFailedPanel()
    {
        failedBuyIAPpanel.SetActive(false);
    }



    public void playClikAudio()
    {
        AudioSourceUI.clip = generalGameSettings.click_sound;
        AudioSourceUI.Play();
    }

    public void loadNextLevel()
    {
        //change prefs files to update player levels status
        LevelGenerator.instance.winlevelUpdateValues();
        win_panel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(1);
    }

    #region  Ui ClickListner 
    public void skipCurentLevel_btn()
    {
        Advertisements.Instance.ShowRewardedVideo(VideoComplete);
        next.SetActive(true);
        // show ads 
        // GameUnityAds.instance.ShowRewardedVideo();
    }
    private void VideoComplete(bool completed)
     {
        if(completed)
        {
           next.SetActive(true);
        }
        else
        {

        }
     }


    public void show_levelList()
    {
        //show level list
        level_panel.SetActive(true);

    }
    public void close_levelList()
    {
        //show level list
        level_panel.SetActive(false);

    }
    public void playerWinLevel()
    {
        win_panel.SetActive(true);
        Advertisements.Instance.ShowInterstitial();
    }

    public void playerLoseLevel()
    {
        losePanel.SetActive(true);
        int lose_time = PlayerPrefs.GetInt("playerloseN_times", 0);
        lose_time++;

        // see if the current time to show interstitia ads or not 
        if (lose_time >= generalGameSettings.showInterstitialAfter_n_lose)
        {
            lose_time = 0;

            //show ads and reassign the value again
            // GameUnityAds.instance.ShowInterstitialAd();
            Advertisements.Instance.ShowInterstitial();
        }
        PlayerPrefs.SetInt("playerloseN_times", lose_time);

    }

    public void RemoveAdsclickButton()
    {
        // removeAdsPanel.SetActive(true);

    }
    public void closeRemoveADSpanel()
    {
        // removeAdsPanel.SetActive(false);

    }

    public void resume_Game()
    {
        // resume game give it the timescale 1
        PausePanel.SetActive(false);
        //Time.timeScale = 1.0f;
    }


    public void Click_SettingsButton()
    {
        settignsPanle.SetActive(true);
    }

    public void closeSettingPanel()
    {
        settignsPanle.SetActive(false);
    }

    public void click_pauseBtn()
    {
        PausePanel.SetActive(true);
        // Invoke("stopTimeScale",1.1f);
        //Time.timeScale = 0f;

    }

    #endregion




}

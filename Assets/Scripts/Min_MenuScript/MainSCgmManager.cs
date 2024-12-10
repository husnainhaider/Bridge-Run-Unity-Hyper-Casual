using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSCgmManager : MonoBehaviour
{

    public static MainSCgmManager instance;

    public GeneralGameSettings general_gamesettings;


    // ui buttons
    public Button sound_BTN;
    public Sprite mutedImage, non_muted_img;

    // ui pannels 
    public GameObject level_panel, shop_panel, settingsPanel, removeAdsPanel, failedAdsPanel;
    public AudioSource main_Ui_source;
    private AudioClip click_Sound;

    public Text priceTextRemoveADS;


    // singilton design pattern
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);

        }
    }






    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        priceTextRemoveADS.text = general_gamesettings.removeAds_price;


        click_Sound = general_gamesettings.click_sound;


        //desable panel on the level loaded
        shop_panel.SetActive(false);
        level_panel.SetActive(false);
        settingsPanel.SetActive(false);
        removeAdsPanel.SetActive(false);
        failedAdsPanel.SetActive(false);


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



    #region  buttons clicked listeners 

    //play button clicked
    public void clickOnPlay()
    {
        //show level ui 
        // choose_the_difficulty_panel.SetActive(true);
        level_panel.SetActive(true);

    }


    public void clickONcloseLevelbtn()
    {
        level_panel.SetActive(false);
    }


    public void clickOnInstagram()
    {
        Application.OpenURL("instagram://user?username=" + general_gamesettings.instagram_username);

    }
    public void clickOnFacebookBtn()
    {
        Application.OpenURL("fb://page/" + general_gamesettings.facebook_page_ID);
    }


    public void clickOnQuit()
    {

        Application.Quit();


    }


    #region SettignsPanel Ui


    public void Click_SettingsButton()
    {
        settingsPanel.SetActive(true);
    }

    public void closeSettingPanel()
    {
        settingsPanel.SetActive(false);
    }

    public void clickOnMoreGames()
    {
        //show more games 
        Application.OpenURL(general_gamesettings.moreGamesLink);
    }



    #region  sound system

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
        sound_BTN.GetComponent<Image>().sprite = mutedImage;
        AudioListener.pause = true;
        //main_Ui_source.mute=main_Ui_source.mute;
        //main_Ui_source.volume=0f;
    }
    public void inmute_audio()
    {
        PlayerPrefs.SetInt("sound_status", 1);  // sound not muted   
        sound_BTN.GetComponent<Image>().sprite = non_muted_img;
        AudioListener.pause = false;
        // main_Ui_source.mute=!main_Ui_source.mute;
        // main_Ui_source.volume=1.0f;




    }

    #endregion


    public void RemoveAdsclickButton()
    {
        removeAdsPanel.SetActive(true);

    }
    public void closeRemoveADSpanel()
    {
        removeAdsPanel.SetActive(false);

    }
    public void ConfirmPlayerWantToBuyIap()
    {

        // you buy the item
        Debug.Log("you buy the itme thanks");

        // we should add a value to player pref to check every Time if the user buy the item or not 
        PlayerPrefs.SetInt("player_buy_no_ads11", 1);   // alwayes when i want to show ads check this value if the user buy this or not 
    }

    public void buyingIapRemoveAdsFailed()
    {
        failedAdsPanel.SetActive(true);
        Invoke("inactiveFailedPanel", 2.2f);
    }
    void inactiveFailedPanel()
    {
        failedAdsPanel.SetActive(false);
    }



    #endregion


    #endregion


    public void playClikAudio()
    {
        main_Ui_source.clip = click_Sound;
        main_Ui_source.Play();

    }


    #region shop

    #endregion
}

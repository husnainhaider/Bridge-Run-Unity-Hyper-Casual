using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopList : MonoBehaviour
{

    public GeneralGameSettings m_gameSettings;


    // prefabs  items
    public Button CarButonPrefab;


    // parents objects
    public Transform carParents;


    public GameObject shop_panel;
    private Button[] tube_list_buttons;

    List<Button> CarsButtonsObjects;

    // Start is called before the first frame update
    void Start()
    {
        carShop_Opened();
        Advertisements.Instance.Initialize();
        
        if(Advertisements.Instance.UserConsentWasSet()==false)
        {
           
        }
        else
        {
         Advertisements.Instance.Initialize();
        }

    }
    void generateCarsButtons()
    {
        CarsButtonsObjects = new List<Button>();

        ShopCars[] CarShopList = m_gameSettings.shopCarsList;
        for (int i = 0; i < CarShopList.Length; i++)
        {
            int copy = i + 1;
            // instantiate buttons 
            Button currentButton = Instantiate(CarButonPrefab, CarButonPrefab.transform.position, Quaternion.identity);
            currentButton.transform.SetParent(carParents.transform, false);

            // give those new buttons listener ... when the buton clicked 
            currentButton.onClick.AddListener(() => selectItem_Car(copy));
            CarsButtonsObjects.Add(currentButton);

        }

        // then setup those buttons give back locked/not ............................................
        int current_level = PlayerPrefs.GetInt("openLevels", 1);   // getting  the number of open levels
        // curentLevel = 1;

        for (int i = 0; i < CarShopList.Length; i++)
        {
            CarsButtonsObjects[i].transform.GetChild(0).GetComponentInChildren<Image>().sprite = CarShopList[i].carSprite_TO_ShowOnShop; // button sprite
                                                                                                                                         // Debug.Log("the number is" + i);



            if (CarShopList[i].levelNumberToOpen >= current_level)
            {
                // desable lock screen

                CarsButtonsObjects[i].interactable = false;
                CarsButtonsObjects[i].transform.GetChild(1).GetComponentInChildren<Image>().gameObject.SetActive(true);

                CarsButtonsObjects[i].transform.GetChild(3).GetComponentInChildren<Text>().text = "level " + CarShopList[i].levelNumberToOpen;  // button level to open

            }
            else
            {
                // enable look screen
                CarsButtonsObjects[i].interactable = true;
                CarsButtonsObjects[i].transform.GetChild(1).GetComponentInChildren<Image>().gameObject.SetActive(false);

                CarsButtonsObjects[i].transform.GetChild(3).GetComponentInChildren<Text>().text = "opened ";  // button level to open

            }

            int selected_item = PlayerPrefs.GetInt("Selected_car", 0);
            if (i == selected_item)
            {
                CarsButtonsObjects[i].transform.GetChild(2).GetComponentInChildren<Image>().gameObject.SetActive(true);
                //PlayerPrefs.SetInt("Selected_tube", selected_item);
            }
        }

    }


    void selectItem_Car(int index)
    {
        Advertisements.Instance.ShowRewardedVideo(VideoComplete);
        int oldselected = PlayerPrefs.GetInt("Selected_car", 0);
        CarsButtonsObjects[oldselected].transform.GetChild(2).GetComponentInChildren<Image>().gameObject.SetActive(false);

        PlayerPrefs.SetInt("Selected_car", index - 1);
        CarsButtonsObjects[index - 1].transform.GetChild(2).GetComponentInChildren<Image>().gameObject.SetActive(true);

    }
    private void VideoComplete(bool completed)
     {
        // if(completed)
        // {
        //     coins+=1000;
        //     CoinText.text = "Coins:" + coins;
        // }
        // else
        // {

        // }
     }

    public void clickOnShopbtn()
    {
        shop_panel.SetActive(true);
    }

    public void closeSHopPanel()
    {
        shop_panel.SetActive(false);

    }


    public void carShop_Opened()
    {

        if (CarsButtonsObjects != null && CarsButtonsObjects.Count != 0)
            destroy_all_buttons(CarsButtonsObjects);

        generateCarsButtons();


    }

    void destroy_all_buttons(List<Button> buttons)
    {


        for (int i = 0; i < buttons.Count; i++)
        {
            Destroy(buttons[i].gameObject);
        }
    }

}

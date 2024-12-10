using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainLevelListManager : MonoBehaviour
{


    public static MainLevelListManager instance;   // sinigliton design pattern

    public GameLevelSettings m_levelSettings; // to get the level settings from 


    //private values
    private int curentLevel; //current leve number 

    public GameObject buttonsParrent;
    public Button levelButtonPrefab;
    List<Button> levelListButton;

    private int difficulty_level;

    private Level[] levels_fordifficlt;




    // Start is called before the first frame update
    void Start()
    {
        instantiateButtons();

    }


    public void instantiateButtons()
    {

        // i want  to store buttons in this list 
        levelListButton = new List<Button>();

        for (int i = 0; i < m_levelSettings.game_levels.Length; i++)
        {
            int copy = i + 1;
            // instantiate buttons 
            Button currentButton = Instantiate(levelButtonPrefab, levelButtonPrefab.transform.position, levelButtonPrefab.transform.rotation);
            currentButton.transform.SetParent(buttonsParrent.transform, false);

            // give those new buttons listener ... when the buton clicked 
            currentButton.onClick.AddListener(() => startLevels(copy));

            // note  : i+1 alawyse when i click any i have the same value .. it's 21


            levelListButton.Add(currentButton);

        }

        settupTheLivelListButtons(levelListButton);

    }




    // give buttons status if it's locked or not 
    void settupTheLivelListButtons(List<Button> buttons)
    {

        Button[] newArray = buttons.ToArray();
        curentLevel = PlayerPrefs.GetInt("openLevels", 1);   // getting  the number of open levels
        for (int i = 0; i < buttons.Count; i++)
        {
            newArray[i].GetComponentInChildren<Text>().text = (i + 1) + "";

            newArray[i].transform.GetChild(0).GetComponentInChildren<Text>().text = i + 1 + "";


            if (i + 1 > curentLevel)
            {
                newArray[i].interactable = false;
                newArray[i].transform.GetChild(1).GetComponentInChildren<Image>().gameObject.SetActive(true);


            }
            else
            {
                newArray[i].transform.GetChild(1).GetComponentInChildren<Image>().gameObject.SetActive(false);

            }


        }

    }


    public void startLevels(int LevelIndex)
    {
        int curentLevelNumber = LevelIndex;
        // save the level index to use in game scean
        PlayerPrefs.SetInt("current level", curentLevelNumber);     //save the current level to get it on the game scen to open the curent level

        //start the game level

        SceanLoader.instance.LoadScean(1);


    }




}

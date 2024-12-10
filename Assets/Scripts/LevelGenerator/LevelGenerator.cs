using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{

    /// <settingupEnvirenemet>
    /// this script levelgenerator is the responsible of creating levels how it does possible 
    /// by taking 
    /// 1) list of levels ... that list that contains levels (level) those levels has proprieties every level has proprieties 
    /// 2) tilemap image , that image contains a scheme of the level structure, so based on that tilemap level gonna created
    /// 3) colortoprefab list ...  a list of color to prefab ( prefabs and corresponding color) 
    /// 
    /// how it works?
    /// by looping in the tilemap image pixels each pixel when he detects a pixel that has a color , the script compares the color of 
    /// that pixel with ColorToPrefab colors ,if there is a match between these two colors he take the corresponding prefab
    /// and instantiate it based on its position on tilemap pic with some offset value 
    ///
    /// 
    ///
    ///    for the game prefabs env 
    /// </summary> 




    // this instance is for singilton desing pattern 
    public static LevelGenerator instance;


    //  public static  int prefabsColorSize;
    // aray of colors to insert in inspector 
    // public Color[] prefabsColors=new Color[prefabsColorSize];


    public GameLevelSettings gameLevelSettings;   // the script will inherts data from that scriptable object
    public GeneralGameSettings m__gameSettings;




    // color to prefab
    //  public Color ground_color, underGround_color, slantedright_color, snaltedleft_color, car_color;

    public Text levletextmainview, leveltext_winPanel, startLevelPanelTxt;


    [Header("prefabs and corresponding color ")]
    [HideInInspector] public ColorToPrefab[] prefabsBasedOnColor;     // the enume of prefab based on color 



    [Header("refrences point postion")]
    public Transform startingPoint;    // the first point in our scen the point that we'r goona use as first point 
                                       //  public Transform mountainPosition;      // public GameObject mountainPrefab;

    // the positions that could be water spawner position the dev should chose one of them
    //public Transform[] spawningWaterPosition;


    [Header("prefabs tipe,water elements")]
    // point when spown water  ... pipe and water 
    //  private GameObject tpipePrefab;    // this prefab is the t pipe ... the pipe to spown water 
    // water drop and spowner 
    // public GameObject WaterSpwnerprefab, waterDropPrefab;  // the water spowner prefab .. for instentiate a prefabe here 


    [Header("levels")]
    private Level[] allLevels;     // a list of levels type level ..... hase the tilemap ..amount of water




    private Vector3 SpawningWaterOffset;


    private Level currentLevel;
    public GameObject platformParent;

    [HideInInspector] public int currentLevelIndex;


    /*   public Levelgenerator(Texture2D aName)
       {
        levelMap= aName;
       }*/

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

    private void Update()
    {


    }


    // Start is called before the first frame update
    void Start()
    {
        // to make screen landscape
        Screen.orientation = ScreenOrientation.Portrait;

        // load custom data from buyer inputs 
        allLevels = gameLevelSettings.game_levels;
        prefabsBasedOnColor = gameLevelSettings.prefabs_based_onColor;
        ///////////////////

        // to be deleted 
        //currentLevelIndex = gameLevelSettings.levleindex;


        currentLevelIndex = PlayerPrefs.GetInt("current level", 1);   // the index of current level
                                                                      // UiManager.instance.updatelevelStatusUi(currentLevelIndex);
        currentLevelIndex--;
        currentLevel = allLevels[currentLevelIndex];
        PlayerPrefs.GetInt("Selected_car", 0);


        // Debug.Log("the enumes type is" + currentLevel.prefabs.ToString());


        //setup the value of level on ui 





        // SpawningWaterOffset = new Vector2(0, -1.33f);

        //generate level Background
        setupUiText(currentLevelIndex++);

        generateLevelEnvironment();
        // generateSpownerSkyMount();

    }

    public void setupUiText(int levelnumber)
    {
        leveltext_winPanel.text = levletextmainview.text = startLevelPanelTxt.text = "Level" + (levelnumber + 1);
    }



    private void generateLevelEnvironment()
    {

        for (int x = 0; x < currentLevel.levelImage.width; x++)
        {
            for (int y = 0; y < currentLevel.levelImage.height; y++)
            {
                //     Debug.Log("the value" + x + y);

                //generate that point
                generateTile(x, y);

            }
        }



    }

    // generate prefabs based on piexlecolor
    void generateTile(int x, int y)
    {

        Color piexleColor = currentLevel.levelImage.GetPixel(x, y);

        if (piexleColor.a == 0)
        {
            // Debug.Log("its alpha equal to 0");
            return;
        }

        //  Debug.Log("the color hash is"+piexleColor.GetHashCode());

        foreach (ColorToPrefab colormapping in prefabsBasedOnColor)
        {

            if (colormapping.color.Equals(piexleColor))
            {
                Vector2 position = new Vector2(x, y);
                Vector2 startPosition = startingPoint.position;


                Vector2 offset = new Vector2(2.8f, 2.8f);

                // the starting positon is   ...   --11.18, -5.4


                if (currentLevel.setDefualtPrefabs == true)
                {
                    //we'r gonna use the default prefabs 

                    foreach (LevelPrefabs item in gameLevelSettings.DefualtPrefabs)
                    {
                        if (item.prefabType.Equals(colormapping.prefabenumName))
                        {
                            //     Debug.Log(item.prefabType.ToString());

                            //check if the item founded is a car to instentiate the selected car form the shop list on main menu
                            if (item.prefabType.Equals(PrefabsLevel.car))
                            {
                                item.prefabObject = m__gameSettings.shopCarsList[PlayerPrefs.GetInt("Selected_car", 0)].carPrefab;
                            }

                            GameObject tielElemnt = Instantiate(item.prefabObject, startPosition + (position * offset), Quaternion.identity);
                            tielElemnt.transform.SetParent(platformParent.transform);
                        }

                    }

                }
                else // when prefabs are not as defualt 
                {
                    foreach (LevelPrefabs item in currentLevel.prefabs)
                    {
                        if (item.prefabType.Equals(colormapping.prefabenumName))
                        {
                            //check if the item founded is a car to instentiate the selected car form the shop list on main menu
                            if (item.prefabType.Equals(PrefabsLevel.car))
                            {
                                item.prefabObject = m__gameSettings.shopCarsList[PlayerPrefs.GetInt("Selected_car", 0)].carPrefab;
                            }
                            //     Debug.Log(item.prefabType.ToString());

                            GameObject tielElemnt = Instantiate(item.prefabObject, startPosition + (position * offset), Quaternion.identity);
                            tielElemnt.transform.SetParent(platformParent.transform);

                        }

                    }
                }

            }

        }
    }



    // instantiate the waterspwoner pipe .... se we'r gonna have some points where we could instantiate pipes ... these points .. gonna be specified ..every level


    /*  void generateSpownerSkyMount()
      {

          //instentiate the backgorund sky 
       //   Instantiate(currentLevel.skyBackgroundPrefab, Vector2.zero, Quaternion.identity);


          // instentiatte mountain prefab
         // Instantiate(currentLevel.mountainPrefab, mountainPosition.position, Quaternion.identity);




      //    GameManger GM = GameManger.instance;   //creat or get a game manager instance


          int spwnposIndex = currentLevel.spwoningPositionNumber;

          // this method gonna instentiate a prefab (t pipe prefab)
          Instantiate(tpipePrefab, spawningWaterPosition[spwnposIndex].position, Quaternion.identity);

          //instantiate spowner water drops ... fro the game manager 
          GM.WaterDrops = Instantiate(waterDropPrefab, spawningWaterPosition[spwnposIndex].position + SpawningWaterOffset, Quaternion.identity);
          GM.WaterSpwner = Instantiate(WaterSpwnerprefab, spawningWaterPosition[spwnposIndex].position + SpawningWaterOffset, Quaternion.identity);

          GM.setUpWaterProperties(currentLevel.waterAmount);   //give the water amount
          waterlevel.instance.levelWaterAmount = currentLevel.waterAmount;
          LineCreator.instance.levelNumberPoint = currentLevel.numberOfLinePoints;   //give the line creator the number of point for line
          LineCreator.instance.UpdateLineStatus();

          AudioClip levelBackSound;
          if (currentLevel.soundBack == null)
          {
              levelBackSound = allLevels[0].soundBack;
          }
          else
          {
              levelBackSound = currentLevel.soundBack;
          }

          GM.setAudiolevelBackground(levelBackSound);




  */

    //}


    public void winlevelUpdateValues()
    {

        PlayerPrefs.SetInt("current level", currentLevelIndex + 1);   // save the curent level ...should be the next level

        PlayerPrefs.SetInt("openLevels", currentLevelIndex + 1);   // save the open levels    


        // i am gonna active it when the game end'sup 


    }


    public int getLevelindex()
    {
        return currentLevelIndex;
    }


}

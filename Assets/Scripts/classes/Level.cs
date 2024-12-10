using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{

    [Header("level Properties")]
    public string level_name;               // level name you can name it what you want but we recommend giving it a name on this way (level +number of level) should be like level 1 
    public Texture2D levelImage;     // the archtecture of the level Low image texture tielleve

    public bool setDefualtPrefabs = true;


  /*  [Header("car prefab")]
    public GameObject car_Prefab; // the sky you want to put as a background 
    [Header("underGroundPrefab")]
    public GameObject underground_Prefab; // the sky you want to put as a background 

    [Header("slanted_ground_left")]
    public GameObject slantedgroundleft; // the sky you want to put as a background 

    [Header("slanted_ground_right")]
    public GameObject slantedgroundright; // the sky you want to put as a background */


    public LevelPrefabs[] prefabs;


    /* [Header("mountain prefab")]
     public GameObject mountainPrefab;

     [Header("level prefabs")]
     public LevelPrefabs[] prefabs;    // the prefabs that you'll use for that level what would you use for groun(ex)


     [Header("Background Sound")]
     public AudioClip soundBack;        // the sound palyed on background 
 */





}

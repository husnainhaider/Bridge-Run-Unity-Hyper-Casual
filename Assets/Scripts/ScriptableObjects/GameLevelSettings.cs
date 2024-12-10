using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Level_Settings")]
public class GameLevelSettings : ScriptableObject
{

    public ColorToPrefab[] prefabs_based_onColor;
    public Level[] game_levels;

    public LevelPrefabs[] DefualtPrefabs;

}

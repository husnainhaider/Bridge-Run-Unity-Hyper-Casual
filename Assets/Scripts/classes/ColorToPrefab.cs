
using UnityEngine;


[System.Serializable]
public class ColorToPrefab 
{
    /// <summary>
    /// color to prefab is like a scheme for prefabs .... colors on tilemap and the corresponding prefab
    /// 
    /// for example .... the green color with that hex #ff.... should be the prefab "trees"
    /// 
    /// </summary>

    public PrefabsLevel prefabenumName;     // this is to make it easy to change any color with any prefab you want
    public Color color;  
    
    }


[System.Serializable]
public enum PrefabsLevel    // the type of prefabs we could change 
{
    /// <summary>
    /// 
    /// these are prefabs type that we could change .... each level has the ability to change those prefabse ..
    /// 
    /// for ex you wanna some specific prefabs on level 1  and some others prefabs on other leves
    /// 
    /// 
    /// </summary>

    ground,
    slantedgroundleft,
    underground,
    car,
    slantedgroundright,
    winFlag,
    othercars,
    Obstacles



}


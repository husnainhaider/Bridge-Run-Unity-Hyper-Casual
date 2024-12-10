
using UnityEngine;

[System.Serializable]
public class LevelPrefabs
{
    /// <summary>
    ///
    /// every level has specific prefabs so this is the level prefabs class ....
    /// 
    ///for example level nubmer N have  leve prefabs inputs.... 
    ///
    /// prefabs type is one of prefabslevel type .... ground , city , trees ....ext
    /// prefabs object is the corresponding object  ...
    /// exampel .. level N hase prefabs ,you can change those prefabs by adding a gameobject as a prefab to each type of prefabs 
    /// 
    /// </summary>


    public string name = "prefab";
    public PrefabsLevel prefabType;    // the type of prefab (ground,trees,sky...ext)
    public GameObject prefabObject;    // the prefab you wanna instentiate instead of what the type of prefab 
}

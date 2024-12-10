using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLevelAnimation : MonoBehaviour
{


    public GameObject howtopaly_anime;
    // Start is called before the first frame update


    void finishStartAnime()
    {
        if (PlayerPrefs.GetInt("current level", 1) > 2)
        {
            levelStart();
            return;
        }
        howtopaly_anime.SetActive(true);
        Invoke("levelStart", 2.2f);
    }

    void levelStart()
    {
        Destroy(howtopaly_anime);
        Destroy(gameObject);
    }
    void Start()
    {
        howtopaly_anime.SetActive(false);
    }

}

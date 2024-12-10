using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceanLoader : MonoBehaviour
{

    public static SceanLoader instance;

    public GameObject loadingScreen;
    public Slider slider;
    public Text sliderPrecentage;




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
        loadingScreen.SetActive(false);

    }
    public void LoadScean(int sceneindex)
    {

        StartCoroutine(LoadAsynchronously(sceneindex));

    }


    IEnumerator LoadAsynchronously(int index)
    {
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        while (!operation.isDone)
        {

            int progress = (int)Mathf.Clamp01(operation.progress / .9f);
            sliderPrecentage.text = progress * 100f + "%";
            slider.value = progress;

            yield return null;
        }


    }

}

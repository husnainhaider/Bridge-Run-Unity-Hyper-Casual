using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class music : MonoBehaviour
{
    public Slider m_soundSlider;
    public AudioSource musicaudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (m_soundSlider.value==1)
            {
                musicaudio.volume=1;
            }
        if (m_soundSlider.value==0)
            {
                musicaudio.volume=0;
            }
    }
}

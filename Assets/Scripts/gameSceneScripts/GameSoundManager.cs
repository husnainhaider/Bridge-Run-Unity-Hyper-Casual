using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{

    public static GameSoundManager instance;
    public AudioClip Car_idle, car_horn, winLevlesnd, loseSound, click_sound, car_acceleration, lose_sound_EFF;
    AudioSource audioSource;


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

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayaudioCLip(GamesAudioClipsList audioType)
    {
        switch (audioType)
        {
            case GamesAudioClipsList.car_acceleration:
                {
                    audioSource.clip = car_acceleration;
                    audioSource.Play();
                    audioSource.volume = 0.8f;
                    audioSource.loop = true;
                }
                break;
            case GamesAudioClipsList.car_horn:
                {
                    audioSource.clip = car_horn;
                    audioSource.Play();
                    audioSource.loop = false;
                }
                break;
            case GamesAudioClipsList.Car_idle:
                {
                    audioSource.clip = Car_idle;
                    audioSource.Play();
                    audioSource.loop = true;
                }
                break;
            case GamesAudioClipsList.loseSound:
                {
                    audioSource.clip = loseSound;
                    audioSource.Play();
                    audioSource.loop = true;
                }
                break;
            case GamesAudioClipsList.winLevlesnd:
                {
                    audioSource.clip = winLevlesnd;
                    audioSource.Play();
                    audioSource.loop = true;
                }
                break;
            case GamesAudioClipsList.click_sound:
                {
                    audioSource.clip = click_sound;
                    audioSource.Play();
                    audioSource.loop = true;
                }
                break;
            case GamesAudioClipsList.lose_sound_EFF:
                {
                    audioSource.clip = lose_sound_EFF;
                    audioSource.Play();
                    audioSource.loop = true;
                }
                break;
        }
    }
    public enum GamesAudioClipsList
    {
        Car_idle,
        car_horn,
        winLevlesnd,
        loseSound,
        click_sound,
        car_acceleration,
        lose_sound_EFF,




    }
}

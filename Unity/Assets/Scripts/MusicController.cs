using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    private AudioSource audioSource;
    public static MusicController instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            MusicController.instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void SetVolume(float volume)
    {
        instance.audioSource.volume = volume; 
    }

}

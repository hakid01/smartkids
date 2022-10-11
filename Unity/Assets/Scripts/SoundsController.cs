using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundsController : MonoBehaviour
{
    // Creamos el audioSource y se cargarán los sonidos dinamicamente en función del botón
    private AudioSource audioSource;
    public static SoundsController instance;
    private static string buttonSound;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            SoundsController.instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void SetVolume(float volume)
    {
        instance.audioSource.volume = volume;
    }

    public static void PlaySound()
    {
        //Reproducimos un sonido o otro en función del tag del botón pulsado
        GameObject selectedGO = EventSystem.current.currentSelectedGameObject;
        buttonSound = selectedGO.tag;

        instance.audioSource.clip = (AudioClip)Resources.Load("Audio/" + buttonSound);
        instance.audioSource.Play();

    }
}

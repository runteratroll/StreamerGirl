using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musigSource;

    public AudioSource buttonSource;

    public AudioSource clickSource;
    private void Awake()
    {
        
    }
    public void SetMusicVolume(float volume)
    {
        //PlayerPrefs.GetFloat("volume1");
        musigSource.volume = volume;
        //PlayerPrefs.SetFloat("volume1", volume);
        
    }

    public void SetButtonVolume(float volume)
    {
        //PlayerPrefs.GetFloat("volume2");
        buttonSource.volume = volume;
        //PlayerPrefs.SetFloat("volume2", volume);

    }

    public void SetClickVolume(float volume)
    {
        clickSource.volume = volume;
    }
    public void OnSfx()
    {
        buttonSource.Play();
    }

    public void OnCfx()
    {
        clickSource.Play();
    }
}

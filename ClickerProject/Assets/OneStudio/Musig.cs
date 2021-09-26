using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Musig : MonoBehaviour
{

    AudioSource musingAudio = null;
    
    public AudioClip[] clips;


    private void Awake()
    {
        musingAudio = GetComponent<AudioSource>();

        

        PlayBGM();


    }


    private void PlayBGM()
    {

        musingAudio.clip = clips[0];
        musingAudio.Play();
        musingAudio.playOnAwake = true;
        musingAudio.loop = true;
        
    
    }


   


}

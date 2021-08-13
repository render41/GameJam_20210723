using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    private AudioSource background,sfx;
    void Start()
    {
        background = GetComponent<AudioSource>();
        sfx = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeMusic(AudioClip audioClip)
    {
        background.clip = audioClip;
        background.Play();
    }

  
}

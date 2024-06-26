using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSounds : MonoBehaviour
{
    public AudioClip[] soundsArray;
    public AudioSource audioSrc => GetComponent<AudioSource>();

    public void PlaySound(AudioClip clip, float volume = 1)
    {
        audioSrc.PlayOneShot(clip, volume);
        
    }
}

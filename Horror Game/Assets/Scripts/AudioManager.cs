using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip nightMusic;


    public void ChangeAudio(AudioClip soundToPlay) {

        audioSource.Stop();
        audioSource.clip = soundToPlay;
        audioSource.Play();
    }
}

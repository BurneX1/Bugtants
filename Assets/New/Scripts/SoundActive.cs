using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActive : MonoBehaviour
{
    public AudioSource[] audSrc;
    public AudioClip[] audClip;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < audSrc.Length; i++)
        {
            audSrc[i].clip = audClip[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // SoundPlay() Reproduce el sonido
    public void SoundPlay(int value)
    {
        if (!audSrc[value].isPlaying)
        {
            audSrc[value].Play();
        }
    }
    // SoundStop() Detiene el sonido
    public void SoundStop(int value)
    {
        if (audSrc[value].isPlaying)
        {
            audSrc[value].Stop();
        }
    }
}

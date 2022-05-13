using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActive : MonoBehaviour
{
    [Tooltip("Numero de sonidos de cuanto podra tener")]
    public AudioClip[] audClip;
    [Tooltip("Numero de Audiosources")]
    public AudioSourceComponent[] audComp;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < audComp.Length; i++)
        {
            audComp[i].newSound = new GameObject
            {
                name = "Sfx " + "(" + i + ")",
                tag = "SoundSFX"
            };

            audComp[i].newSound.transform.parent = audComp[i].location.transform;
            audComp[i].newSound.transform.position = audComp[i].location.transform.position;
            audComp[i].audSrc = audComp[i].newSound.AddComponent(typeof(AudioSource)) as AudioSource;
            audComp[i].audSrc.rolloffMode = AudioRolloffMode.Linear;
            audComp[i].audSrc.spatialBlend = 1;
            audComp[i].audSrc.minDistance = audComp[i].soundDistance.x;
            audComp[i].audSrc.maxDistance = audComp[i].soundDistance.y;
        }
    }

    // SoundPlay() Reproduce el sonido
    public void SoundPlay(int value, int clip)
    {
        if (!audComp[value].audSrc.isPlaying)
        {
            audComp[value].audSrc.clip = audClip[clip];
            audComp[value].audSrc.Play();
        }
    }
    // SoundStop() Detiene el sonido
    public void SoundStop(int value, int clip)
    {
        if (audComp[value].audSrc.isPlaying)
        {
            audComp[value].audSrc.clip = audClip[clip];
            audComp[value].audSrc.Stop();
        }
    }
}

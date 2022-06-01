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
        foreach (AudioSourceComponent audines in audComp)
        {
            audines.newSound = new GameObject
            {
                name = "Sfx",
                tag = "SoundSFX"
            };
            audines.newSound.transform.parent = audines.location.transform;
            audines.newSound.transform.position = audines.location.transform.position;
            audines.audSrc = audines.newSound.AddComponent(typeof(AudioSource)) as AudioSource;
            audines.audSrc.rolloffMode = AudioRolloffMode.Linear;
            audines.audSrc.spatialBlend = 1;
            audines.audSrc.playOnAwake = false;
            audines.audSrc.minDistance = audines.soundDistance.x;
            audines.audSrc.maxDistance = audines.soundDistance.y;
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

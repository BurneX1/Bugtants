using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource), typeof(VolumeValue))]
public class SpawneableSFX : MonoBehaviour
{
    [HideInInspector]
    public AudioSource audSrc;
    [HideInInspector]
    public AudioClip clippie;
    private VolumeValue volumeScript;
    private VolumeConfiguration volConfig;
    [Range(0, 1)]
    public float capVolume;

    // Start is called before the first frame update
    void Awake()
    {
        audSrc = GetComponent<AudioSource>();
        audSrc.clip = clippie;
        volumeScript = GetComponent<VolumeValue>();
        volConfig = GameObject.FindGameObjectWithTag("Pause").GetComponent<VolumeConfiguration>();
        volConfig.SoundChange();
        audSrc.volume = volumeScript.volValue * capVolume;
        audSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        soundEffectSounder();
    }

    void soundEffectSounder()
    {
        if (audSrc.volume != volumeScript.volValue * capVolume)
            audSrc.volume = volumeScript.volValue * capVolume;
        if (!audSrc.isPlaying)
            Destroy(gameObject);
    }
}

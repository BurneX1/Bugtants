using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource),typeof(VolumeValue))]
public class SoundsCapingVolume : MonoBehaviour
{
    [HideInInspector]
    public AudioSource audSrc;
    private VolumeValue volumeScript;
    [Range(0, 1)]
    public float capVolume;

    // Start is called before the first frame update
    void Awake()
    {
        audSrc = GetComponent<AudioSource>();
        volumeScript = GetComponent<VolumeValue>();
    }

    // Update is called once per frame
    void Update()
    {
        SoundsCapingSounder();
    }

    void SoundsCapingSounder()
    {
        if (audSrc.volume != volumeScript.volValue * capVolume)
        audSrc.volume = volumeScript.volValue * capVolume;
    }
}

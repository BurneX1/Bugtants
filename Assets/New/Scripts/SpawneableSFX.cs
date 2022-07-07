using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource), typeof(VolumeValue))]
public class SpawneableSFX : MonoBehaviour
{
    private AudioSource audSrc;
    private VolumeValue volumeScript;
    private VolumeConfiguration volConfig;
    [Range(0, 1)]
    public float capVolume;

    // Start is called before the first frame update
    void Awake()
    {
        audSrc = GetComponent<AudioSource>();
        volumeScript = GetComponent<VolumeValue>();
        volConfig = GameObject.FindGameObjectWithTag("Pause").GetComponent<VolumeConfiguration>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

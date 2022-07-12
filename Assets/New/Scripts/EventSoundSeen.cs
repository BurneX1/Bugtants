using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSoundSeen : MonoBehaviour
{
    public AudioClip clippie;
    private AudioSource whisper;
    public Detecter soundZone;
    private VolumeValue volumeScript;
    [Range(0, 1)]
    public float capVolume;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Whisperer");
        whisper = obj.GetComponent<AudioSource>();
        volumeScript = obj.GetComponent<VolumeValue>();
    }

    // Update is called once per frame
    void Update()
    {
        ZoneDetecter();
    }

    void ZoneDetecter()
    {
        if (whisper.volume != volumeScript.volValue * capVolume)
            whisper.volume = volumeScript.volValue * capVolume;
        if (soundZone.touch)
        {
            whisper.clip = clippie;

            whisper.Play();
            Destroy(gameObject);
        }

    }
}

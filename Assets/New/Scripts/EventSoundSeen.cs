using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSoundSeen : MonoBehaviour
{
    public AudioClip clippie;
    private AudioSource whisper;
    public Detecter soundZone;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Whisperer");
        whisper = obj.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ZoneDetecter();
    }

    void ZoneDetecter()
    {
        if (soundZone.touch)
        {
            whisper.clip = clippie;
            whisper.Play();
            Destroy(gameObject);
        }

    }
}
